using System.Data;
using System.Data.SqlClient;

namespace ConApp.DbOp
{
    public class MyDataAdapter
    {
        private readonly string _sql;
        private readonly SqlConnection _con;

        public MyDataAdapter(string sql, SqlConnection con)
        {
            this._sql = sql;
            this._con = con;
        }

        public void Fill(DataSet ds, string dtName)
        {
            DataTable dt = ds.Tables.Add(dtName);
            dt.Columns.Add("CustomerID");
            dt.Columns.Add("CompanyName");
            using (SqlCommand cmd = _con.CreateCommand())
            {
                cmd.CommandText = _sql;
                _con.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["CustomerID"] = sdr.GetInt64(0);
                    dr["CompanyName"] = sdr.GetString(1);
                    dt.Rows.Add(dr);
                }
                sdr.Close();
                dt.AcceptChanges();
            }
        }
    }
}