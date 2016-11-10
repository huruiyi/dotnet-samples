using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;

namespace SSHOP
{
    public class LoginHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string admin = context.Request.Form["username"];
            string pwd = context.Request.Form["password"];
            string sql = "select count(*) from dbo.T_Admin where userName=@userName and userPwd=@userPwd ";
            int result = SQLHelper.ExecuteScalar(sql,
                new SqlParameter("@userName", admin),
                new SqlParameter("@userPwd", pwd));
            if (result == 1)
            {
                context.Session["sadmin"] = admin;
                context.Session["spwd"] = pwd;
                context.Response.Redirect("GoodsDetails.html");
            }
            else
            {
                //string html = context.Response.WriteFile(context.Server.MapPath("~/Index.htm"));

                context.Response.Write("登录失败");
            }
        }
    }
}