using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using MVC.Sample.Controllers;

namespace MVC.Sample.Infrastructure
{
    public class CusAControllerFactory : IControllerFactory
    {
        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            //在这里，为了简单，我不管当前http请求信息是什么，都生成HomeController实例。
            Type targetType = typeof(HomeController);
            return (IController)DependencyResolver.Current.GetService(targetType);
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