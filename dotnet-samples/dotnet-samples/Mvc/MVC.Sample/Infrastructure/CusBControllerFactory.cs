using System;
using System.Web.Mvc;
using System.Web.SessionState;
using MVC.Sample.Controllers;

namespace MVC.Sample.Infrastructure
{
    public class CusBControllerFactory : IControllerFactory
    {
        public SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            Type controllerType = typeof(HomeController);
            switch (controllerName)
            {
                case "demoa":
                    controllerType = typeof(DemoAController);
                    break;

                case "demob":
                    controllerType = typeof(DemoBController);
                    break;

                default:
                    requestContext.RouteData.Values["controller"] = "Home";
                    requestContext.RouteData.Values["action"] = "index";
                    break;
            }
            return (IController)DependencyResolver.Current.GetService(controllerType);
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}