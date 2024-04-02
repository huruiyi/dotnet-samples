using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Infrastructure
{
    public class LogFilter : ActionFilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// This method call before excute Action Method
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string msg = "\n" + DateTime.Now + "--" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "----" + filterContext.ActionDescriptor.ActionName + "--" + "OnActionExecuting";
            LogDetails(msg);
        }

        /// <summary>
        /// This method call after excute Action Method
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string msg = "\n" + DateTime.Now + "--" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "----" + filterContext.ActionDescriptor.ActionName + "--" + "OnActionExecuted";
            LogDetails(msg);
        }

        /// <summary>
        /// This method call after excute Result
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = "\n" + DateTime.Now + "--" + filterContext.RouteData.Values["controller"] + "----" + filterContext.RouteData.Values["action"] + "--" + "OnResultExecuted";
            LogDetails(msg);
        }

        /// <summary>
        /// This method call before excute Result
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = "\n" + DateTime.Now + "--" + filterContext.RouteData.Values["controller"] + "----" + filterContext.RouteData.Values["action"] + "--" + "OnResultExecuting";
            LogDetails(msg);
        }

        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            string msg = "\n" + DateTime.Now + "--" + filterContext.RouteData.Values["controller"] + "----" + filterContext.RouteData.Values["action"] + "--" + "OnException";
            LogDetails(msg);
        }

        private void LogDetails(string logData)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Log/Log.txt"), logData);
        }
    }
}