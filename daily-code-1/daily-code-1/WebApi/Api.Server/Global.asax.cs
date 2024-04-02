using Api.Server.Infrastructure;
using System.Web.Http;

namespace Api.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new HttpMethodOverrideHandler());
        }
    }
}