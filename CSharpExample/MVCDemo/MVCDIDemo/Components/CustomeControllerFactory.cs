using MVCDIDemo.Controllers;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MVCDIDemo.Components
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            ILogger logger = new DefaultLogger();
            var controller = new HomeController(logger);
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
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