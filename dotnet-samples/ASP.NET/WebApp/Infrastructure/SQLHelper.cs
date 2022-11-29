using System;
using System.Data.SqlClient;

namespace WebApp.Infrastructure
{
    public class SQLHelper
    {
        private static string ConString = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] sps)
        {
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (sps != null)
            {
                foreach (SqlParameter item in sps)
                {
                    cmd.Parameters.Add(item);
                }
            }
            return cmd.ExecuteReader();
        }

        public static int ExecuteScalar(string sql, params SqlParameter[] sps)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (sps != null)
                    {
                        foreach (SqlParameter item in sps)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] sps)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (sps != null)
                    {
                        foreach (SqlParameter item in sps)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}