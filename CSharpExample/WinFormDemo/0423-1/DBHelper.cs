using System.Data;
using System.Data.SqlClient;

namespace _0423_1
{
    internal class DBHelper
    {
        //获取连接字符串第一种方式
        public static string constring =
        @"server=.;database=MySchoolBase;uid=sa;pwd=sa";

        public static string constring1 =
        @"Data Source=.;Initial Catalog=MySchoolBase;Integrated Security=True";

        public static string Getconstring()
        {
            //SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            //获取连接字符串第二种方式 sql认证方式

            //scsb.DataSource = ".";
            //scsb.InitialCatalog = "MySchoolBase";
            //scsb.UserID = "sa";
            //scsb.Password = "sa";

            //windows认证方式连接数据库字符串
            //scsb.DataSource = ".";
            //scsb.InitialCatalog = "MySchoolBase";
            //scsb.IntegratedSecurity = true;
            //return scsb.ConnectionString;

            //获取连接字符串第三种方式 配置文件
            //return ConfigurationManager.AppSettings["constring"];
            //return ConfigurationManager.ConnectionStrings["conString"].ToString();

            //获取连接字符串第四种方式 Properties
            return Properties.Settings.Default.constring;
        }

        public static int ExcuteNoQuerry(string sql)
        {
            using (SqlConnection cn = new SqlConnection(DBHelper.Getconstring()))
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ExcuteQuerry(string sql)
        {
            SqlConnection cn = new SqlConnection(DBHelper.Getconstring());

            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}