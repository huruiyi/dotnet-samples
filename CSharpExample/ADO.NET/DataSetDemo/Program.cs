using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataSetDemo
{
    internal class Program
    {
        private static string ConString = "Data Source=.;Initial Catalog=Northwind;uid=sa;pwd=sa";
        private static string Constring_ExampleDb = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";

        private static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                string sql = "select CustomerID,CompanyName from Customers order by CustomerID";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "CusTempTable");
                foreach (DataRow customers in ds.Tables["CusTempTable"].Rows)
                {
                    Console.WriteLine(customers[0] + "   " + customers["CompanyName"]);
                }
            }

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string sql = "select CustomerID,CompanyName from Customers order by CustomerID";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Customers");

                DataTable dt = ds.Tables["Customers"]; DataRow dr = dt.NewRow(); dr["CustomerID"] =
                "aaaaa1"; dr["CompanyName"] = "11111"; dt.Rows.Add(dr);

                dr = dt.NewRow(); dr["CustomerID"] = "aaaaa2"; dr["CompanyName"] = "222222"; dt.Rows.Add(dr);

                foreach (DataRow customers in ds.Tables["Customers"].Rows)
                {
                    Console.WriteLine(customers[0] + "   " + customers["CompanyName"]);
                }
            }

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string sql = "select CustomerID,CompanyName from Customers order by CustomerID";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Customers");

                DataTable dt = ds.Tables["Customers"];
                DataRow dr = dt.NewRow();
                dr["CustomerID"] = "aa1";
                dr["CompanyName"] = "11111";
                dt.Rows.Add(dr);

                DataRow dr2 = dt.NewRow();
                dr2["CustomerID"] = "aa2";
                dr2["CompanyName"] = "222222";
                dt.Rows.Add(dr2);

                string ins = "insert into Customers(CustomerID,CompanyName) values(@CustomerID,@CompanyName)";
                using (SqlCommand cmd = new SqlCommand(ins, con))
                {
                    sda.InsertCommand = cmd;
                    sda.InsertCommand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");
                    sda.InsertCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
                    sda.Update(dt);
                }
                foreach (DataRow customers in ds.Tables["Customers"].Rows)
                {
                    Console.WriteLine(customers[0] + "   " + customers["CompanyName"]);
                }
            }

            Console.Read();
        }

        public void DataViewDemo()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                string sql = "select CustomerID,CompanyName,City,Country from Customers";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Customers");
                DataTable tb = ds.Tables["Customers"];
                DataView dv = new DataView();
                dv.Table = tb;
                dv.RowFilter = "Country='USA'";
                dv.Sort = "City DESC";

                int index = dv.Find("Portland");
                //Find要根据Sort，若Find值不唯一，则获取索引最最小的值
                DataRowView drIndex = dv[index];
                Console.WriteLine(drIndex["CustomerID"] + "  " + drIndex["CompanyName"] + "  " + drIndex["City"] + "  " + drIndex["Country"]);
                Console.WriteLine("***************************************************************");

                //Find要根据Sort，若Find值不唯一，则获取所有满足的索引值
                DataRowView[] drvPortland = dv.FindRows("Portland");
                for (int i = 0; i < drvPortland.Length; i++)
                {
                    Console.WriteLine(drvPortland[i]["CustomerID"] + "  " + drvPortland[i]["CompanyName"] + "  " + drvPortland[i]["City"] + "  " + drvPortland[i]["Country"]);
                }
                Console.WriteLine("***************************************************************");

                foreach (DataRowView drv in dv)
                {
                    Console.WriteLine(drv["CustomerID"] + "  " + drv["CompanyName"] + "  " + drv["City"] + "  " + drv["Country"]);
                }
            }
        }

        public void DataRowSelect()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                string sql = "select CustomerID,CompanyName,City,Country from Customers";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Customers");
                // ds.Tables["Customers"].PrimaryKey = new DataColumn[] {
                // ds.Tables["Customers"].Columns["CustomerID"] };//设置主键
                DataTable tb = ds.Tables["Customers"];
                tb.PrimaryKey = new DataColumn[] { tb.Columns["CustomerID"] };

                //根据主键值查询筛选
                DataRow drResult = tb.Rows.Find("ALFKI");
                if (drResult != null)
                {
                    Console.WriteLine(drResult["CustomerID"] + "\n" + drResult["CompanyName"] + "\n" + drResult["City"] + "\n" + drResult["Country"] + "\n");
                }

                //多条件查询筛选
                DataRow[] drs = tb.Select("Country='USA'", "CompanyName DESC");
                foreach (DataRow dr in drs)
                {
                    Console.WriteLine(dr[0] + "  " + dr[1] + " " + dr[2] + "  " + dr[3]);
                }

                foreach (DataRow customers in ds.Tables["Customers"].Rows)
                {
                    Console.WriteLine(customers["CustomerID"] + "\n" + customers["CompanyName"] + "\n" + customers["City"] + "\n" + customers["Country"] + "\n");
                }
            }
        }

        public void DataSetCreate1()
        {
            DataSet ds = new DataSet();
            DataTable tbl;
            DataColumn col;

            tbl = ds.Tables.Add("Customers");
            tbl.Columns.Add("CustomerID", typeof(string)).MaxLength = 5;
            tbl.Columns.Add("CompanyName", typeof(string)).MaxLength = 40;
            tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CustomerID"] };

            tbl = ds.Tables.Add("Orders");
            col = tbl.Columns.Add("OrderID", typeof(int));
            col.AutoIncrement = true;
            col.AutoIncrementSeed = -1;
            col.AutoIncrementStep = -1;
            col.ReadOnly = true;
            tbl.PrimaryKey = new DataColumn[] { tbl.Columns["OrderID"] };

            col = tbl.Columns.Add("CustomerID", typeof(string));
            col.MaxLength = 5;
            col.AllowDBNull = false;

            ForeignKeyConstraint fk = new ForeignKeyConstraint("FK_Customers_Orders", ds.Tables["Customers"].Columns["CustomerID"], ds.Tables["Orders"].Columns["CustomerID"]);

            DataRow dr = ds.Tables["Customers"].NewRow();
            dr["CustomerID"] = "id1";
            dr["CompanyName"] = "aa";
            ds.Tables["Customers"].Rows.Add(dr);

            DataTable customers = ds.Tables["Customers"];
            dr = customers.Rows[0];
            dr["CustomerID"] = "dsada";
            dr["CompanyName"] = DBNull.Value;

            //customers.Rows.Remove(dr);
            //customers.Rows[0].Delete();

            dr = ds.Tables["Customers"].NewRow();
            dr["CustomerID"] = "id2";
            dr["CompanyName"] = "bb";
            ds.Tables["Customers"].Rows.Add(dr);

            dr = ds.Tables["Customers"].NewRow();
            dr["CustomerID"] = "id3";
            dr["CompanyName"] = DBNull.Value;
            ds.Tables["Customers"].Rows.Add(dr);

            foreach (DataRow row in ds.Tables["Customers"].Rows)
            {
                //if (row == ds.Tables["Customers"].Rows[0])
                //{
                //    row["CustomerID"] = "id11";
                //    row["CompanyName"] = "aaa";
                //}
                if (row["CompanyName"] == DBNull.Value)
                {
                    row["CompanyName"] = "NULL";
                }
                Console.WriteLine(row["CustomerID"] + " " + row["CompanyName"]);
            }
        }

        public void DataSetCreate2()
        {
            DataSet ds = new DataSet("MyDataBase");

            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("sID")
            {
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };
            dt.Columns.Add(dc);

            dc = new DataColumn("sName")
            {
                MaxLength = 5,
                DataType = typeof(string)
            };
            dt.Columns.Add(dc);

            dc = new DataColumn("sSex")
            {
                DataType = typeof(char),
                DefaultValue = '男'
            };
            dt.Columns.Add(dc);

            dc = new DataColumn("sAge")
            {
                AllowDBNull = true,
                DataType = typeof(int)
            };
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["sName"] = "小明";
            dr["sSex"] = '男';
            dr["sAge"] = 18;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["sName"] = "小兰";
            dr["sSex"] = '女';
            dr["sAge"] = 20;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["sName"] = "新一";
            dr["sSex"] = '男';
            dr["sAge"] = 19;
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);

            foreach (DataRow drs in dt.Rows)
            {
                Console.WriteLine(drs[0] + "　" + drs["sName"] + " " + drs["sSex"] + " " + drs["sAge"]);
            }
        }

        public void MyDataAdapterDemo()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                string sql = "select CustomerID,CompanyName from Customers";
                MyDataAdapter sda = new MyDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Customers");
                foreach (DataRow customers in ds.Tables["Customers"].Rows)
                {
                    Console.WriteLine(customers[0] + "" + customers["CompanyName"]);
                }
            }
        }

        public void StoredProcedureDemo1()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertStuInfo";//存储过程的名字
                    cmd.Parameters.AddWithValue("@Name", "kangkang");
                    cmd.Parameters.AddWithValue("@Sex", "男");
                    int result = cmd.ExecuteNonQuery();
                    Console.WriteLine(result + "行受影响");
                }
            }
        }

        public void StoredProcedureDemo2()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    string stuName = "";//  定义初始化参数[SearchNameBysID（@ID int ,@Name nvarchar(10)） output]
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SearchNameBysID";//存储过程的名字
                    cmd.Parameters.AddWithValue("@ID", 1);
                    cmd.Parameters.AddWithValue("@Name", stuName);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        Console.WriteLine(sdr["sName"]);
                    }
                    else
                    {
                        Console.WriteLine("对应ID编号无学生存在");
                    }
                }
            }
        }

        public static DataSet CreateCmdsAndUpdate(string sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Constring_ExampleDb))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                con.Open();
                adapter.Fill(ds);
                adapter.Update(ds);
            }
            return ds;
        }

        public static void DataSetDemo1()
        {
            Program pg = new Program();
            DataSet ds = CreateCmdsAndUpdate("select * from Admin");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Console.Write("账户：" + item["aAdmin"] + "\t");
                Console.WriteLine("密码：" + item["aPassword"]);
            }
        }

        public static void DataSetDemo2()
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection con = new SqlConnection(Constring_ExampleDb))
            {
                string sql = "select * from Admin";
                using (SqlDataAdapter sdsa = new SqlDataAdapter(sql, con))
                {
                    sdsa.Fill(ds1, "Admin");
                }
            }
            foreach (DataRow item in ds1.Tables[0].Rows)
            {
                Console.Write("账户：" + item["aAdmin"] + "\t");
                Console.WriteLine("密码：" + item["aPassword"]);
            }
        }

        public static void DataSetDemo3()
        {
            DataSet ds2 = new DataSet();
            using (SqlConnection con = new SqlConnection(Constring_ExampleDb))
            {
                //string sql = "select * from Admin\nUpdate Admin set aAdmin='张c三' where aID=1";
                string sql = "Update Admin set aAdmin='张三1' where aID=1\nselect * from Admin";
                using (SqlDataAdapter sdsa = new SqlDataAdapter(sql, con))
                {
                    sdsa.Fill(ds2, "Admin");
                }
            }

            foreach (DataRow item in ds2.Tables["Admin"].Rows)
            {
                Console.Write("账户：" + item["aAdmin"] + "\t");
                Console.WriteLine("密码：" + item["aPassword"]);
            }
        }

        public static void DataSetDemo4()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Constring_ExampleDb))
            {
                string sql = "select * from Admin";

                using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                {
                    sda.Fill(ds, "Admin");

                    //写入XML文档
                    //ds.Tables["Admin"].WriteXml("aaa.XML");
                    //ds.Tables["Admin"].WriteXmlSchema("b.XML");

                    //添加新行操作！
                    DataRow dr = ds.Tables["Admin"].NewRow();
                    dr["aAdmin"] = "aJarry1";
                    dr["aPassword"] = "aJarry1";
                    ds.Tables["Admin"].Rows.Add(dr);

                    //删除行的操作
                    for (int i = 0; i < ds.Tables["Admin"].Rows.Count; i++)
                    {
                        if (ds.Tables["Admin"].Rows[i]["aAdmin"].ToString() == "aJarry1")
                        {
                            ds.Tables["Admin"].Rows[i].Delete();
                            // ds.Tables["Admin"].Rows.Remove(ds.Tables["Admin"].Rows[i]);
                            Console.WriteLine("aJarry1被删除");
                        }
                    }

                    //修改操作
                    for (int i = 0; i < ds.Tables["Admin"].Rows.Count; i++)
                    {
                        if (ds.Tables["Admin"].Rows[i]["aID"].ToString() == "5")
                        {
                            ds.Tables["Admin"].Rows[i]["aPassword"] = "ceshimima";
                        }
                    }
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    sda.Update(ds.Tables["Admin"]);
                }
            }
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Console.WriteLine(item[0] + "  " + item["aAdmin"] + "  " + item["aPassword"]);
            }
        }

        public static void DataSetDemo5()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con1 = new SqlConnection(Constring_ExampleDb))
            {
                string sql = "Update Admin set aAdmin='ffkkf' where aId=7 \nselect * from Admin";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con1);
                sda.Fill(ds);
                SqlCommandBuilder bulider = new SqlCommandBuilder(sda);
                ds.Tables[0].Clear();
                sda.Fill(ds);
                //sda.Update(ds);
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine(dr[0] + "  " + dr["aAdmin"] + "  " + dr["aPassword"]);
            }
        }

        public static void DataTableDemo1()
        {
            DataTable table = new DataTable("table");

            DataColumn idColumn = new DataColumn("id", typeof(Int32)) { AutoIncrement = true };
            DataColumn itemColumn = new DataColumn("item", typeof(string));
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);

            for (int i = 0; i < 10; i++)
            {
                DataRow newRow = table.NewRow();
                newRow["item"] = "Item " + i;
                table.Rows.Add(newRow);
            }
            table.AcceptChanges();

            DataRowCollection itemColumns = table.Rows;
            itemColumns[0].Delete();
            itemColumns[2].Delete();
            itemColumns[3].Delete();
            itemColumns[5].Delete();
            Console.WriteLine(itemColumns[3].RowState.ToString());

            // Reject changes on one deletion.
            itemColumns[3].RejectChanges();

            // Change the value of the column so it stands out.
            itemColumns[3]["item"] = "Deleted, Undeleted, Edited";

            // Accept changes on others.
            table.AcceptChanges();

            // Print the remaining row values.
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(row[0] + "\table" + row[1]);
            }
        }

        public static void DataTableDemo2()
        {
            const string connectionString = "Data Source=.;Initial Catalog=BBS;uid=sa;pwd=sa";
            DataTable dt = new DataTable("Student");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("select * from Student", con))
                {
                    sda.Fill(dt);
                }
            }

            DataView dv = dt.DefaultView;
            dv.RowFilter = "Province='河南'";
            dt = dv.ToTable(true, "Name", "Sex", "Province");

            dv.AllowDelete = true;
            dv.Delete(2);
            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow[0] + "  " + dataRow[1] + " " + dataRow[2]);
            }

            dv.Dispose();
        }

        public static void AttachDbDemo()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\") || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            Console.WriteLine("请输入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            //  string ConStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\T_Test.mdf;Integrated Security=True;User Instance=True";
            string ConStr = @"Data Source=.;AttachDbFilename=|DataDirectory|\T_Test.mdf;uid=sa;pwd=sa";
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"select * from T_Test Where UserName='{username}'";
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            string dbpassword = read.GetString(read.GetOrdinal("Password"));
                            Console.WriteLine(password == dbpassword ? "登陆成功" : "密码错误，登录失败");
                        }
                        else
                        {
                            Console.WriteLine("无此用户名！");
                        }
                    }
                }
            }
        }
    }
}