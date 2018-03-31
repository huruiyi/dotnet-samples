using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Sample.Infrastructure
{
    /// <summary>
    /// ControllerBuilder.Current.SetControllerFactory(new CusIocControllerFactory());实现依赖注入
    /// </summary>
    public class CusIocControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //"MVC.Sample.Models.MathService, MVC.Sample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            // string s = typeof(MathService).AssemblyQualifiedName;

            var constructor = controllerType.GetConstructors()[0];
            ParameterInfo[] parameters = constructor.GetParameters();
            var paramNames = parameters.Select(a =>
            {
                var serviceType = (ServiceAttribute)(a.ParameterType.GetCustomAttributes(typeof(ServiceAttribute), true)[0]);
                return Activator.CreateInstance(Type.GetType(serviceType.ServiceName, true));
            }).ToArray();
            IController controller = Activator.CreateInstance(controllerType, paramNames) as Controller;
            return controller;
        }
    }
}