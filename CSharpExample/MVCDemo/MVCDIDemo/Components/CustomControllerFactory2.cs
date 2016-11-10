using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
 
namespace MVCDIDemo.Components
{
    public class CustomControllerFactory2 : IControllerFactory
    {
        private readonly string _controllerNamespace;
        public CustomControllerFactory2(string controllerNamespace)
        {
            _controllerNamespace = controllerNamespace;
        }
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            ILogger logger = new DefaultLogger();
            Type controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));
            IController controller = Activator.CreateInstance(controllerType, new[] { logger }) as Controller;
            return controller;
        }
        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        public void ReleaseController(IController controller)
        {
            //cleanup code
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}