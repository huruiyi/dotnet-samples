using System.Data;
using System.Data.SqlClient;

namespace _0423_2
{
    public class DBHelper
    {
        //第一种获取连接字符串方式
        public static string conString = "server=.;database=MySchoolBase;uid=sa;pwd=sa";

        public static string GetConstring()
        {
            //第二种获取连接字符串方式
            //SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            //sb.DataSource = ".";
            //sb.InitialCatalog = "MySchoolBase";
            ////sb.UserID = "sa";
            ////sb.Password = "sa";
            //sb.IntegratedSecurity = true;

            //return sb.ConnectionString;

            //第三种获取连接字符串方式,操作配置文件
            //return ConfigurationManager.AppSettings["constring"];
            //return ConfigurationManager.ConnectionStrings["constring1"].ToString();

            //第四种获取连接字符串方式,操作配置文件
            return Properties.Settings.Default.constring;
        }

        public static int ExcuteNoQuerry(string sql)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = GetConstring();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ExcuteQuerry(string sql)
        {
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = GetConstring();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}