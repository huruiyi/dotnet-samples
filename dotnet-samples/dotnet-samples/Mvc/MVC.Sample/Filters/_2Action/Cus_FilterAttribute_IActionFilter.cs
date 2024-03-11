using System;
using System.Web.Mvc;

namespace MVC.Sample.Fliters._2Action
{
    public class Cus_FilterAttribute_IActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnActionExecuted</br>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string url = filterContext.RequestContext.HttpContext.Request.Url.ToString();
            string ip = filterContext.RequestContext.HttpContext.Request.UserHostAddress;
            string browser = filterContext.RequestContext.HttpContext.Request.Browser.Browser;
            string os = filterContext.RequestContext.HttpContext.Request.Browser.Platform;
            DateTime currentDate = DateTime.Now;

            filterContext.HttpContext.Response.Write("OnActionExecuting</br>");
        }
    }
}