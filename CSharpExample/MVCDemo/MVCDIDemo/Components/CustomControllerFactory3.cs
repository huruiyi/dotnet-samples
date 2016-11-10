using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCDIDemo.Components
{
    public class CustomControllerFactory3 : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            ILogger logger = new DefaultLogger();
            IController controller = Activator.CreateInstance(controllerType, new[] { logger }) as Controller;
            return controller;
        }
    }

    public class CustomDepResolver : IDependencyResolver
    {
        object IDependencyResolver.GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}