using System.Web.Mvc;

namespace MVC.Sample.Filters
{
    public class MVCAPPActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName.ToString();
            filterContext.HttpContext.Response.Write($"OnActionExecuting---{actionName}</br>");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName.ToString();
            filterContext.HttpContext.Response.Write($"OnActionExecuted---{actionName}</br>");

            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuting</br>");
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuted</br>");
            base.OnResultExecuted(filterContext);
        }
    }
}