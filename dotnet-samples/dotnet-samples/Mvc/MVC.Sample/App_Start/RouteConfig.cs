using System.Web.Mvc;
using System.Web.Routing;
using MVC.Sample.Infrastructure;

namespace MVC.Sample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            //配置自定义约束
            routes.MapRoute("Article", "blog/{year}/{month}/{day}",
                new
                {
                    controller = "blog",
                    action = "show",
                    author = "miracle",
                    year = "",
                    month = "",
                    day = ""
                },
                new
                {
                    year = new RouteConstraint.YearRouteConstraint(),
                    month = new RouteConstraint.MonthRouteConstraint(),
                    day = new RouteConstraint.DayRouteConstraint()
                });
        }
    }
}
