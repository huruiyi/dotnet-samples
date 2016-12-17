using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApp.Page.SessionSample
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
                string html = File.ReadAllText(context.Server.MapPath("~/Page/SessionSample/LoginTemp.html"));
                context.Response.Write(html);
            }
            else if (context.Request.HttpMethod == "POST")
            {
                string uid = context.Request.Form["username"];
                string pwd = context.Request.Form["password"];

                context.Session["suid"] = uid;
                context.Session["spwd"] = pwd;
                context.Response.Redirect("homepage");
            }
        }
    }
}