using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHost.WebApi
{
    /**
     * https://learn.microsoft.com/zh-cn/aspnet/web-api/overview/older-versions/self-host-a-web-api
     * 添加Package:
     * Microsoft.AspNet.WebApi.SelfHost
     */
    internal class Program
    {
        private static HttpSelfHostConfiguration config = new HttpSelfHostConfiguration("http://localhost:8080");

        private static void Main(string[] args)
        {
            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}