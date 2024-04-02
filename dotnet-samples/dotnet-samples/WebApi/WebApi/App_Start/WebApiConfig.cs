using Ninject;
using System.Web.Http;
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
            config.EnableCors();

            //var cors = new EnableCorsAttribute("http://localhost:815/", "*", "*");
            //cors.Origins.Add("http://localhost:816/");
            //cors.Origins.Add("http://localhost:817/");
            //config.EnableCors(cors);

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
