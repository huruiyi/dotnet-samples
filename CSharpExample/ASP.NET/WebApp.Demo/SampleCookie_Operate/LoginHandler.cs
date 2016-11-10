using System;
using System.IO;
using System.Web;

namespace SampleCookie_Operate
{
    public class LoginHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                if (context.Request.Cookies["userid"] != null && context.Request.Cookies["userpwd"] != null)
                {
                    context.Response.Write(context.Request.Cookies["userid"].Value);
                    context.Response.Write(context.Request.Cookies["userid"].Name);
                    context.Response.Write(context.Request.Cookies["userid"].Path);
                    context.Response.Redirect("index.htm");
                }
                else
                {
                    string html = File.ReadAllText(context.Server.MapPath("~/SampleCookie_Operate/LoginTemp.html"));
                    context.Response.Write(html);
                }
            }
            else if (context.Request.HttpMethod == "POST")
            {
                string uid = context.Request.Form["username"];
                string pwd = context.Request.Form["password"];

                string isRemember = context.Request.Form["rememberstatus"];
                if (isRemember == "on")
                {
                    HttpCookie hcuid = new HttpCookie("userid", uid);
                    hcuid.Expires = DateTime.Now.AddHours(1);
                    context.Response.Cookies.Add(hcuid);

                    HttpCookie hcpwd = new HttpCookie("userpwd", pwd);
                    hcpwd.Expires = DateTime.Now.AddHours(1);
                    context.Response.Cookies.Add(hcpwd);
                }
                context.Response.Write("你的用户名是:" + uid + "你的密码是:" + pwd);
            }
        }
    }
}