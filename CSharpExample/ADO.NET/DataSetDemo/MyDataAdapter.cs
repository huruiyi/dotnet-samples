using System.Data;
using System.Data.SqlClient;

namespace DataSetDemo
{
    class MyDataAdapter
    {
        private string sql;
        private SqlConnection con;

        public MyDataAdapter(string sql, SqlConnection con)
        {
            this.sql = sql;
            this.con = con;
        }

        public void Fill(DataSet ds, string dtName)
        {
            DataTable dt = ds.Tables.Add(dtName);
            dt.Columns.Add("CustomerID");
            dt.Columns.Add("CompanyName");
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = sql;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["CustomerID"] = sdr.GetString(0);
                    dr["CompanyName"] = sdr.GetString(1);
                    dt.Rows.Add(dr);
                }
                sdr.Close();
                dt.AcceptChanges();
            }
        }
    }
}
