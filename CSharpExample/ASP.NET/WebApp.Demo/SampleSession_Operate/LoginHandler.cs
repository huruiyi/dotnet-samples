using System.IO;
using System.Web;
using System.Web.SessionState;//使用Session时需要用到此命名空间

namespace SampleSession_Operate
{
    public class LoginHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                string html = File.ReadAllText(context.Server.MapPath("~/SampleSession_Operate/LoginTemp.html"));
                context.Response.Write(html);
            }
            else if (context.Request.HttpMethod == "POST")
            {
                string uid = context.Request.Form["username"];
                string pwd = context.Request.Form["password"];

                context.Session["suid"] = uid;
                context.Session["spwd"] = pwd;
                context.Response.Redirect("homepage.html");
            }
        }
    }
}