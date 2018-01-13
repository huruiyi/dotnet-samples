using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ninject;
using WebApi.Models;
using WebApiContrib.IoC.Ninject;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ICommentRepository>().ToConstant(new InitialData());
            config.DependencyResolver = new NinjectResolver(kernel);

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
