using System.Data.SqlClient;
using System.Web;
using WebApp.Infrastructure;

namespace WebApp.Handler
{
    /// <summary>
    /// Product_LoginHandler 的摘要说明
    /// </summary>
    public class Product_LoginHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string admin = context.Request.Form["username"];
            string pwd = context.Request.Form["password"];
            string sql = "select count(*) from dbo.Admin where userName=@userName and userPwd=@userPwd ";
            int result = SQLHelper.ExecuteScalar(sql,
                new SqlParameter("@userName", admin),
                new SqlParameter("@userPwd", pwd));
            if (result == 1)
            {
                context.Session["sadmin"] = admin;
                context.Session["spwd"] = pwd;
                context.Response.Redirect("GoodsDetails");
            }
            else
            {
                context.Response.Write("登录失败");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}