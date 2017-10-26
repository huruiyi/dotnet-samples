using MVC.Sample.Models;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.Mvc;

namespace MVC.Sample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new UnityContainer();
            container.RegisterType<IUser, SimpleUser>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
        }
    }
}