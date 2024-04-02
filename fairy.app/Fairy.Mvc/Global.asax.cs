using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fairy.Mvc.Infrastructure;
using log4net.Config;

namespace Fairy.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //example 1:
            //AssemblyInfo.cs [assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
            LogHelper.SetConfig();
            //XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            //example 2:
            //XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/App_Config/log4net-v3.config")));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //在出现未处理的错误时运行的代码
            Exception objExp = HttpContext.Current.Server.GetLastError();

            LogHelper.WriteLog("\r\n客户机IP:" + Request.UserHostAddress + "\r\n错误地址:" + Request.Url + "\r\n异常信息:" + Server.GetLastError().Message, objExp);
        }
    }
}
