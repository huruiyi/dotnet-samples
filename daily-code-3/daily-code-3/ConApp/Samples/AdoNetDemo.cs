using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace ConApp.Samples
{
    public class AdoNetDemo
    {
        public class ConStringConfiguration
        {
            public static string ConString3 = "server=.;database=ExampleDb;uid=sa;Pwd=sa";
            public static string ConString4 = "Data Source=.;Initial Catalog=ExampleDb;InteGrated Security=true";

            public static string GetConstring1()
            {
                SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
                s.DataSource = ".";
                s.InitialCatalog = "ExampleDb";
                s.IntegratedSecurity = true;
                string ConString1 = s.ConnectionString;
                return ConString1;
            }

            public static string GetConstring2()
            {
                SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
                s.DataSource = ".";
                s.InitialCatalog = "ExampleDb";
                s.UserID = "sa";
                s.Password = "sa";
                string ConString2 = s.ConnectionString;
                return ConString2;
            }

            public static string GetConstring3()
            {
                return ConfigurationManager.AppSettings["ConString5"];
            }

            public static string GetConstring4()
            {
                return ConfigurationManager.ConnectionStrings["ConString6"].ToString();
            }

            public static string GetConstring5()
            {
                //return Properties.Resources.ConString7;
                return "";
            }
        }

        private const string ConnectionString = @"server=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";

        public static void Con1()
        {
            string connectionString = ConStringConfiguration.GetConstring1();
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = connectionString;
            con1.Open();
            Console.WriteLine(con1.State.ToString(), "数据库状态");
        }

        public static void Con2()
        {
            string connectionString = ConStringConfiguration.GetConstring2();
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = connectionString;
            con2.Open();
            Console.WriteLine(con2.State.ToString(), "数据库状态");
        }

        public static void Con3()
        {
            string connectionString = ConStringConfiguration.ConString3;
            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = connectionString;
            con3.Open();
            Console.WriteLine(con3.State.ToString(), "数据库状态");
        }

        public static void Con4()
        {
            string connectionString = ConStringConfiguration.ConString4;
            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = connectionString;
            con4.Open();
            Console.WriteLine(con4.State.ToString(), "数据库状态");
        }

        public static void Con5()
        {
            string connectionString = ConStringConfiguration.GetConstring3();
            SqlConnection con5 = new SqlConnection(connectionString);
            con5.Open();
            Console.WriteLine(con5.State.ToString(), "数据库状态");
        }

        public static void Con6()
        {
            string connectionString = ConStringConfiguration.GetConstring4();
            SqlConnection con6 = new SqlConnection();
            con6.ConnectionString = connectionString;
            con6.Open();
            Console.WriteLine(con6.State.ToString(), "数据库状态");
        }

        public static void Con7()
        {
            string connectionString = ConStringConfiguration.GetConstring5();
            SqlConnection con7 = new SqlConnection(connectionString);
            con7.Open();
            Console.WriteLine(con7.State.ToString(), "数据库状态");
        }

        public static void ExecuteScalarDemo1()
        {
            Console.WriteLine("请输入用户名：");
            string UserName = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string PassWord = Console.ReadLine();
            using (SqlConnection con3 = new SqlConnection(ConnectionString))
            {
                string sql = "select count(*) from Admin where UserName=@UserName and Password=@Password";
                using (SqlCommand cmd = new SqlCommand(sql, con3))
                {
                    con3.Open();
                    SqlParameter sp1 = new SqlParameter("@UserName", UserName);
                    cmd.Parameters.Add(sp1);
                    SqlParameter sp2 = new SqlParameter("@Password", PassWord);
                    cmd.Parameters.Add(sp2);

                    int Result = (int)cmd.ExecuteScalar();
                    if (Result > 0)
                    {
                        Console.WriteLine("登陆成功！！");
                    }
                    else
                    {
                        Console.WriteLine("登录失败！！");
                    }
                }
            }
        }

        public static void ExecuteScalarDemo2()
        {
            Console.WriteLine("请输入要插入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入要插入密码：");
            string password = Console.ReadLine();
            using (SqlConnection con3 = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con3.CreateCommand();
                cmd.CommandText = string.Format("insert into Admin (UserName,Password)  values('{0}','{1}');select @@identity", username, password);
                con3.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Console.WriteLine("数据插入成功");
                }
                else
                {
                    Console.WriteLine("数据插入失败");
                }
            }
        }

        public static void ExecuteScalarDemo3()
        {
            Console.WriteLine("请输入要插入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入要插入密码：");
            string password = Console.ReadLine();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = string.Format(@"insert into Admin (UserName,Password)  output inserted.ID values('{0}','{1}')", username, password);
                con.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Console.WriteLine("数据插入成功");
                }
                else
                {
                    Console.WriteLine("数据插入失败");
                }
            }
        }

        //执行登陆功能  注入登陆：  1' or '1'='1
        public static void ExecuteScalarDemo4()
        {
            Console.WriteLine("请输入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = string.Format("select count(*) from Admin where UserName='{0}'and Password='{1}'", username, password);
                con.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Console.WriteLine("成功");
                }
                else
                {
                    Console.WriteLine("失败");
                }
            }
        }

        public static void ExecuteScalarDemo5()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConnectionString;
                SqlCommand cmd = new SqlCommand();
                string commandText = "select 1 from Admin where ID=1";

                cmd.Connection = con;
                cmd.CommandText = commandText;
                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                if (Convert.ToInt32(result) > 0)
                {
                    Console.WriteLine("成功");
                }
                else
                {
                    Console.WriteLine("失败");
                }
            }
        }

        public static void ExecuteScalarDemo6()
        {
            using (SqlConnection con2 = new SqlConnection())
            {
                con2.ConnectionString = ConnectionString;

                string sql2 = "select count(*) from Admin ";

                SqlCommand cmd = con2.CreateCommand();
                cmd.CommandText = sql2;
                con2.Open();
                int Result = (int)cmd.ExecuteScalar();
                Console.WriteLine(Result);
            }
        }

        public static void ExecuteReaderDemo1()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConnectionString;
                SqlCommand cmd = new SqlCommand();
                string commandText = "select UserName,Password from Admin";

                cmd.Connection = con;
                cmd.CommandText = commandText;
                con.Open();
                SqlDataReader sdr1 = cmd.ExecuteReader();
                while (sdr1.Read())
                {
                    //Console.WriteLine("用户名："+sdr1[0]);
                    //Console.WriteLine("密码："+sdr1[1]);

                    //Console.WriteLine("用户名：" + sdr1["UserName"]);
                    //Console.WriteLine("密码：" + sdr1["Password"]);

                    //Console.WriteLine("用户名：" + sdr1.GetString(sdr1.GetOrdinal("UserName")));
                    //Console.WriteLine("密码：" + sdr1.GetString(sdr1.GetOrdinal("Password")));

                    Console.WriteLine("用户名：" + sdr1.GetString(0));
                    Console.WriteLine("密码：" + sdr1.GetString(1));

                    Console.WriteLine();
                }
            }
        }

        public static void ExecuteReaderDemo2()
        {
            using (SqlConnection con2 = new SqlConnection(ConnectionString))
            {
                string sql2 = string.Format("select * from Admin where ID=1");
                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                con2.Open();
                SqlDataReader sdt = cmd2.ExecuteReader();
                while (sdt.Read())
                {
                    Console.WriteLine("用户名：" + sdt["UserName"] + ",密码：" + sdt["Password"]);
                }
            }
        }

        public static void ExecuteNonQueryDemo1()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("请输入要删除的用户名Id：");
                string userId = Console.ReadLine();
                int intUserId = Convert.ToInt32(userId);
                string cmdText = string.Format("delete from Admin where Id={0}", intUserId);
                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("删除数据成功");
                }
                else
                {
                    Console.WriteLine("删除数据失败");
                }
            }
        }

        public static void ExecuteNonQueryDemo2()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("请输入要添加的用户名：");
                string username = Console.ReadLine();
                Console.WriteLine("请输入用户密码：");
                string password = Console.ReadLine();
                string cmdText = string.Format("insert into Admin (UserName,Password) values ('{0}','{1}')", username, password);
                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("数据添加成功");
                }
                else
                {
                    Console.WriteLine("数据添加失败");
                }
            }
        }

        public static void SqlDataAdapterDemo()
        {
            string commandText = "select UserName,Password from Admin";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(commandText, con);
                con.Open();
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Admin");
                foreach (DataRow row in dataSet.Tables["Admin"].Rows)
                {
                    Console.WriteLine("UserName:{0},Password:{1}", row["UserName"], row["Password"]);
                }
                Console.ReadKey();
            }
        }

        private static void SqlAddTest()
        {
            string conString = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string cmdText =
                    "insert into ExampleDb.dbo.Info ( UserId,ContentInfo,CreateTime ) values ( @UserId,@ContentInfo,@CreateTime )";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@UserId", 1000 + i);
                        cmd.Parameters.AddWithValue("@ContentInfo", $"ContentInfo{1000 + i}");
                        cmd.Parameters.AddWithValue("@CreateTime", DateTime.Now.AddMinutes(-100 * i).AddMinutes(i + 35));
                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine(result > 0 ? "添加成功" : "添加失败");
                    }
                }
            }
        }

        private static void SqlReadTest()
        {
            string conString = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                string cmdText = "select * from [ExampleDb].[dbo].[Info] with(nolock)";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.Write(reader["Id"] + "\t");
                        Console.Write(reader["UserId"] + "\t");
                        Console.Write(reader["ContentInfo"] + "\t");
                        Console.WriteLine(reader["CreateTime"] + "\t");
                    }
                }

                Console.WriteLine(con.State);
            }
        }

        public static void SqlDemo()
        {
            #region 获取插入WDModule表数据返回的ID

            const string connectionString = "user id=TCLXSWD;password=I47kY7%vIK25@e$;DataBase=TCB2bTouristBasic;server=192.168.0.154,1441;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                const string sql = @"INSERT    INTO dbo.WDModule
                                ( Name, SortType, BasePath, DefaultOrder, GroupId, IfValid,
                                  IfHaveCategory )
                        OUTPUT    INSERTED.id,INSERTED.DefaultOrder
                        VALUES  ( '自助游', 1, '/wd/lines/type2/4_', 130, 100, 1, 0 ),
                                ( '出境游', 1, '/wd/lines/type2/3_', 131, 100, 1, 0 ),
                                ( '国内游', 1, '/wd/lines/type2/2_', 132, 100, 1, 0 ),
                                ( '周边游', 1, '/wd/lines/type2/1_', 133, 100, 1, 0 )
                          ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                List<string> listMoudleIdList = new List<string>();
                while (sqlDataReader.Read())
                {
                    listMoudleIdList.Add(sqlDataReader[0].ToString());
                }
            }

            #endregion 获取插入WDModule表数据返回的ID

            #region 获取WdMenu表 --会员的数量及会员Id集合

            List<string> listB2BUserId = new List<string>();
            int b2BUserCount = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"DECLARE @tempTable TABLE
                                (
                                  rownumber INT IDENTITY(1, 1)
                                                PRIMARY KEY ,
                                  B2bUserId INT
                                )
                            INSERT  INTO @tempTable
                                    SELECT DISTINCT
                                            ( B2bUserId )
                                    FROM    dbo.WDMenu
                            SELECT rownumber ,B2bUserId FROM @tempTable";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    listB2BUserId.Add(dataReader["B2bUserId"].ToString());
                }
                b2BUserCount = listB2BUserId.Count;
            }

            #endregion 获取WdMenu表 --会员的数量及会员Id集合

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $@"DECLARE @maxOrderNumber INT
                                            DECLARE @B2bUserId INT
                                            DECLARE @rowNumber INT
                                            SET @rowNumber = 1
                                            WHILE @rowNumber <= {b2BUserCount}
                                                BEGIN
                                                    SELECT  @B2bUserId = B2bUserId
                                                    FROM    @tempTable
                                                    WHERE   rownumber = @rowNumber
                                                    SELECT  @maxOrderNumber = MAX(ordernum)
                                                    FROM    dbo.WDMenu
                                                    WHERE   B2bUserId = @B2bUserId
                                                    INSERT  INTO dbo.WDMenu
                                                            ( B2bUserId, Name, ModuleId, LinkUrl, OrderNum, IfShow )
                                                    VALUES  ( @B2bUserId, N'自助游', 53, N'', @maxOrderNumber + 1, 1 )
                                                   ,        ( @B2bUserId, N'出境游', 54, N'', @maxOrderNumber + 2, 1 )
                                                   ,        ( @B2bUserId, N'国内游', 55, N'', @maxOrderNumber + 3, 1 )
                                                   ,        ( @B2bUserId, N'周边游', 56, N'', @maxOrderNumber + 4, 1 )
                                                    SET @rowNumber = @rowNumber + 1
                                                END";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public static void StopwatchDemo()
        {
            DataTable dt = GetMainTable();

            Stopwatch sw = new Stopwatch();
            int doCount = 0;
            var dataIEnum = dt.AsEnumerable();
            sw.Start();
            for (int i = 0; i < 50000; i++)
            {
                if (dataIEnum.Count() > 0)
                    doCount++;
            }
            sw.Stop();
            Console.WriteLine("Count() 耗費時間：" + sw.ElapsedMilliseconds / 1000d);

            sw.Reset();
            doCount = 0;
            sw.Start();
            for (int i = 0; i < 50000; i++)
            {
                if (dataIEnum.Any())
                    doCount++;
            }
            sw.Stop();
            Console.WriteLine("Any() 耗費時間：" + sw.ElapsedMilliseconds / 1000d);
            List<DataRow> dataList = dataIEnum.ToList();
            sw.Reset();
            doCount = 0;
            sw.Start();
            for (int i = 0; i < 50000; i++)
            {
                if (dataList.Count > 0)
                    doCount++;
            }
            sw.Stop();
            Console.WriteLine("List.Count 耗費時間：" + sw.ElapsedMilliseconds / 1000d);
        }

        public static DataTable GetMainTable()
        {
            DataTable dt = new DataTable();
            DataColumn dataColumn = new DataColumn("Id", typeof(int))
            {
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                AutoIncrement = true
            };
            dt.Columns.AddRange(new[]
            {
                dataColumn,
                new DataColumn("Name", typeof (string)), new DataColumn("Age", typeof (int)),
                new DataColumn("BirthDay", typeof (DateTime))
            });
            for (int i = 0; i < 100; i++)
            {
                dt.Rows.Add(i, "Name" + i, 2 * i, DateTime.Now);
            }
            return dt;
        }

        public static void StoredProcedureDemo()
        {
            string conString = "Data Source=.;Initial Catalog=Demo;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string cmdText = "pro_GetLast";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int);
                    parameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parameter);
                    cmd.CommandType = CommandType.StoredProcedure;
                    object result = cmd.ExecuteNonQuery();
                    Console.WriteLine(result + "  " + parameter.SqlValue);
                }
            }
        }
    }
}