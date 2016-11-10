using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace HW
{
    public class DeleteProductHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string proid = context.Request.QueryString["pd"];
            string imagePath = context.Server.MapPath(string.Format("~/Images/{0}.jpg", proid));
            if (imagePath != null)
            {
                File.Delete(imagePath);
            }
            string ConString = "Data Source=.;Initial Catalog=ProductManage;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string sql = "delete from Product where ProductID=@pid";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@pid", proid);
                    cmd.ExecuteNonQuery();
                    context.Response.Redirect("proList.aspx");
                }
            }
        }
    }
}