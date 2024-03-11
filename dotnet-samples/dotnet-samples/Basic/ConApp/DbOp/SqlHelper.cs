using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConApp.DbOp
{
    internal class SqlHelper
    {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["SQLhelp"].ToString();

        public static SqlDataReader MyDataReader(string cmdText, CommandType cmdType, params SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                conn.Open();
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static Object MyExecuteScalar(string cmdText, CommandType cmdType, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    cmd.CommandType = cmdType;
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static int MyExecuteNonQuery(string cmdText, CommandType cmdType, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    cmd.CommandType = cmdType;
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}