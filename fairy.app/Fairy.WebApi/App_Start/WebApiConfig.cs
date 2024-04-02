using Fairy.WebApi.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Fairy.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
             * 　IIS拒绝PUT和DELETE请求是由于IIS为网站默认注册的一个名为WebDAVModule的自定义HttpModule导致的，
             * 如果我们的站点不需要提供针对WebDAV的支持，解决这个问题最为直接的方式就是利用如下配置将注册的HttpModule移除即可：
             *<system.webServer>  
                 <modules runAllManagedModulesForAllRequests="true">  
                   <remove name="WebDAVModule" />  
                 </modules>  
                 <handlers>
                    <remove name="WebDAV" />
                 </handlers>
               </system.webServer>
             */
            //如果调用ASP.NET Web API不能发送PUT/DELETE请求怎么办？
            //https://www.cnblogs.com/artech/p/3606873.html
            config.MessageHandlers.Add(new HttpMethodOverrideHandler());

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
