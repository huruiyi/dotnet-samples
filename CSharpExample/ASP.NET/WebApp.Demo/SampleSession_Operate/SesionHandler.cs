using System.Web;
using System.Web.SessionState;

namespace SampleSession_Operate
{
    public class SesionHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["suid"] != null && context.Session["spwd"] != null)
            {
                context.Response.Write("你输入的用户名是:" + context.Session["suid"] + ",密码是:" + context.Session["spwd"]);
            }
            else
            {
                context.Response.Redirect("login.html");
            }
        }
    }
}