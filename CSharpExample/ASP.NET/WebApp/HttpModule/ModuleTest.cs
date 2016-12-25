using System;
using System.Web;

namespace WebApp.HttpModule
{
    public class ModuleTest : IHttpModule
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>

        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            context.LogRequest += new EventHandler(OnLogRequest);

            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Response.ContentType = "text/html";
            context.Response.Write("<hr><h1><font color=red>HelloWorldModule: End of Request</font></h1>");
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Response.ContentType = "text/html";

            context.Response.Write("<h1><font color=red> HelloWorldModule: Beginning of Request</font></h1><hr>");

            //设置页面请求等待5秒钟
            System.Threading.Thread.Sleep(new System.Random().Next(5000));
        }

        #endregion IHttpModule Members

        public void OnLogRequest(Object source, EventArgs e)
        {
        }
    }
}