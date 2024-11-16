using System;
using System.Web;
using System.Web.UI;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-3.7.1.min.js",
                DebugPath = "~/scripts/jquery-3.7.1.js",
                CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.7.1.min.js",
                CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.7.1.js"
            });
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string originalPath = HttpContext.Current.Request.Path.ToLower();
            if (originalPath.Contains("/page1"))
            {
                Context.RewritePath(originalPath.Replace("/page1", "/RewritePath.aspx?page=page1"));
            }
            if (originalPath.Contains("/page2"))
            {
                Context.RewritePath(originalPath.Replace("/page2", "/RewritePath.aspx"), "pathinfo", "page=page2");
            }

            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}