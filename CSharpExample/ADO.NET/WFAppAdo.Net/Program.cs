using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace WFAppAdo.Net
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Demo4();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DataSetExample());
        }

        private static void Demo1()
        {
            ExampleDbDataSet.CustomersDataTable sss = new ExampleDbDataSet.CustomersDataTable();
            ExampleDbDataSetTableAdapters.CustomersTableAdapter ss = new ExampleDbDataSetTableAdapters.CustomersTableAdapter();
            ss.Fill(sss);
            StringBuilder sbBuilder = new StringBuilder();
            foreach (ExampleDbDataSet.CustomersRow ct in sss.Rows)
            {
                sbBuilder.Append(ct.CustomerID + "  " + ct.CompanyName + Environment.NewLine);
            }
            MessageBox.Show(sbBuilder.ToString());
        }

        private static void Demo2()
        {
            ExampleDbDataSet nds = new ExampleDbDataSet();

            ExampleDbDataSetTableAdapters.CustomersTableAdapter ndsAdapter = new ExampleDbDataSetTableAdapters.CustomersTableAdapter();
            ndsAdapter.Fill(nds.Customers);

            StringBuilder sbBuilder = new StringBuilder();
            foreach (ExampleDbDataSet.CustomersRow ct in nds.Customers.Rows)
            {
                sbBuilder.Append(ct.CustomerID + "  " + ct.CompanyName + Environment.NewLine);
            }

            DataRow CustomersdrALFKI = nds.Customers.Rows.Find(1);
            sbBuilder.Append(CustomersdrALFKI["CompanyName"]);
            MessageBox.Show(sbBuilder.ToString());
        }

        private static void Demo3()
        {
            ExampleDbDataSet nds = new ExampleDbDataSet();

            ExampleDbDataSetTableAdapters.OrdersTableAdapter ordTblApt = new ExampleDbDataSetTableAdapters.OrdersTableAdapter();
            ordTblApt.Fill(nds.Orders);

            StringBuilder sbBuilder = new StringBuilder();

            foreach (ExampleDbDataSet.OrdersRow ordRow in nds.Orders.Rows)
            {
                sbBuilder.Append(ordRow.OrderID + "  " + ordRow.CustomerID + "  " + ordRow.OrderDate + Environment.NewLine);
            }
            MessageBox.Show(sbBuilder.ToString());
        }

        public static void Demo4()
        {
            ExampleDbDataSet nds = new ExampleDbDataSet();

            ExampleDbDataSetTableAdapters.CustomersTableAdapter ndsAdapter = new ExampleDbDataSetTableAdapters.CustomersTableAdapter();
            ndsAdapter.Fill(nds.Customers);

            ExampleDbDataSetTableAdapters.OrdersTableAdapter ordTblApt = new ExampleDbDataSetTableAdapters.OrdersTableAdapter();
            ordTblApt.Fill(nds.Orders);

            //通过Customers表中的CustomerID(主键)查找Orders表中对应的数据
            ExampleDbDataSet.CustomersRow cusRow1 = (ExampleDbDataSet.CustomersRow)nds.Customers.Rows.Find(1);
            ExampleDbDataSet.CustomersRow cusRow2 = nds.Customers.FindByCustomerID(1);
            StringBuilder sbBuilder = new StringBuilder();

            foreach (var rowResult in cusRow1.GetOrdersRows())
            {
                sbBuilder.Append(rowResult.OrderID + " " + rowResult.OrderDate + "  " + rowResult.CustomerID + Environment.NewLine);
            }

            foreach (var rowResult in cusRow2.GetOrdersRows())
            {
                sbBuilder.Append(rowResult.OrderID + " " + rowResult.OrderDate + "  " + rowResult.CustomerID + Environment.NewLine);
            }

            //通过Orders表中的CustomerID(外键)查找Customers表中的数据
            ExampleDbDataSet.OrdersRow ordRowResult = (ExampleDbDataSet.OrdersRow)nds.Orders.Rows.Find(1);

            sbBuilder.Append(ordRowResult.CustomerID + Environment.NewLine);
            sbBuilder.Append(ordRowResult.OrderDate + Environment.NewLine);

            //修改数据
            ExampleDbDataSet.CustomersRow cr = ordRowResult.CustomersRow;
            sbBuilder.Append(cr.CustomerID);
            sbBuilder.Append(cr.CompanyName);
            cr.CompanyName = "name19:44";
            ndsAdapter.Update(cr);
            Console.WriteLine(cr.CompanyName);

            //修改数据
            ExampleDbDataSet.CustomersRow cusRow = nds.Customers.FindByCustomerID(1);
            cusRow.CompanyName = "MyCompanyName";
            ndsAdapter.Update(cusRow);
            Console.WriteLine(cusRow.CompanyName);

            //添加一行数据
            ExampleDbDataSet.CustomersRow newRow = nds.Customers.AddCustomersRow("aMyName");
            ndsAdapter.Update(newRow);

            //删除一行数据
            ndsAdapter.Delete(4, "aMyName");

            MessageBox.Show(sbBuilder.ToString());
        }

        public static void Demo5()
        {
            const string conStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Id from Admin";
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine(sdr[0]);
            }
            sdr.Close();
            cmd.Clone();
            con.Close();
        }

        public static void Demo6()
        {
            Console.WriteLine("第1种打开数据库的方法");
            SqlConnection con = new SqlConnection(GetCoString4());
            con.Open();
            MessageBox.Show(con.State.ToString());
        }

        public static void Demo7()
        {
            Console.WriteLine("第2种打开数据库的方法");
            SqlConnection con = new SqlConnection { ConnectionString = GetCoString4() };
            con.Open();
            MessageBox.Show(con.State.ToString());
        }

        public static void Demo8()
        {
            Console.WriteLine("第3种打开数据库的方法");
            SqlConnection con = new SqlConnection { ConnectionString = GetCoString4() };
            con.Open();
            MessageBox.Show(con.State.ToString());
        }

        public static void Demo9()
        {
            SqlConnection con1 = new SqlConnection { ConnectionString = GetCoString4() };
            con1.Open();
            MessageBox.Show(con1.State.ToString());
            con1.Close();
            MessageBox.Show(con1.State.ToString());
        }

        public static string GetCoString1()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "ExampleDb",
                IntegratedSecurity = true
            };
            return scsb.ConnectionString;
        }

        public static string GetCoString2()
        {
            return ConfigurationManager.AppSettings["ConString1"];
        }

        public static string GetCoString3()
        {
            return ConfigurationManager.ConnectionStrings["ConStringName1"].ToString();
        }

        public static string GetCoString4()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "ExampleDb",
                UserID = "sa",
                Password = "sa"
            };
            return scsb.ConnectionString;
        }
    }
}