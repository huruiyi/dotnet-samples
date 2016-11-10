using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Ado.Net_Connection
{
    internal class Program
    {
        public static string Constring1 = @"Data Source=.;Initial Catalog=MySchoolBase;Integrated Security=True";

        public static string Constring2 = @"server=.;database=MySchoolBase;uid=sa;pwd=sa";

        public static string GetCoString1()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "MySchoolBase",
                IntegratedSecurity = true
            };
            return scsb.ConnectionString;
        }

        public static string GetCoString2()
        {
            return ConfigurationManager.AppSettings["conString1"];
        }

        public static string GetCoString3()
        {
            return ConfigurationManager.ConnectionStrings["conString2"].ToString();
        }

        public static string GetCoString4()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "MySchoolBase",
                UserID = "sa",
                Password = "sa"
            };
            return scsb.ConnectionString;
        }

        private static void Main()
        {
            //const string conStr = "Data Source=.;Initial Catalog=MySchoolBase;uid=sa;pwd=sa";
            //SqlConnection con = new SqlConnection(conStr);
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "select LoginID from Admin";
            //SqlDataReader sdr = cmd.ExecuteReader();
            //while (sdr.Read())
            //{
            //    Console.WriteLine(sdr[0]);
            //}
            //sdr.Close();
            //cmd.Clone();
            //con.Close();
            //Console.ReadKey();

            //Console.WriteLine("第1种打开数据库的方法");
            //SqlConnection con1 = new SqlConnection(Constring1);
            //con1.Open();
            //Console.WriteLine(con1.State.ToString());

            //Console.WriteLine("第2种打开数据库的方法");
            //SqlConnection con2 = new SqlConnection { ConnectionString = Constring2 };
            //con2.Open();
            //Console.WriteLine(con2.State.ToString());

            //Console.WriteLine("第3种打开数据库的方法");
            //SqlConnection con3 = new SqlConnection { ConnectionString = GetCoString3() };
            //con3.Open();
            //Console.WriteLine(con3.State.ToString());

            //Console.ReadKey();

            //const string conStr1 = "Data Source=.;Initial Catalog=MySchoolBase;uid=sa;pwd=sa";
            //SqlConnection con1 = new SqlConnection { ConnectionString = conStr1 };
            //con1.Open();
            //Console.WriteLine(con1.State.ToString());
            //con1.Close();
            //Console.WriteLine(con1.State.ToString());

            //const string conStr2 = "server=.;database=MySchoolbase;uid=sa;pwd=sa";
            //SqlConnection con2 = new SqlConnection(conStr2);
            //con2.Open();
            //Console.WriteLine(con2.State.ToString());
            //con2.Close();
            //Console.WriteLine(con2.State.ToString());

            //SqlConnectionStringBuilder s = new SqlConnectionStringBuilder
            //  {
            //      DataSource = ".",
            //      InitialCatalog = "MySchoolBase",
            //      UserID = "sa",
            //      Password = "sa"
            //  };
            //string conStr3 = s.ConnectionString;
            //SqlConnection con3 = new SqlConnection
            //{
            //    ConnectionString = conStr3
            //};
            //con3.Open();
            //Console.WriteLine(con3.State.ToString());
            //con3.Close();
            //Console.WriteLine(con3.State.ToString());

            SqlConnectionStringBuilder s1 = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "MySchoolBase",
                IntegratedSecurity = true
            };
            string conStr4 = s1.ConnectionString;
            SqlConnection con4 = new SqlConnection(conStr4);
            con4.Open();
            Console.WriteLine(con4.State.ToString());
            con4.Close();
            Console.WriteLine(con4.State.ToString());
        }
    }
}