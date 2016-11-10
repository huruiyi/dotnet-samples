using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCFilter.Fliters._2Action

{
    public class Cus_ActionFilterAttribute : ActionFilterAttribute
    {
        public string Roles { get; set; }     //应传入的功能权限值

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            IDictionary<string, object> parameters = filterContext.ActionParameters;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            filterContext.HttpContext.Response.Write("OnActionExecuting</br><br />");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object obj = filterContext.Result;
            string resultType = obj.GetType().Name;
            switch (resultType)
            {
                case "ContentResult":
                    break;

                case "ViewResult":
                    break;

                default:
                    break;
            }
            filterContext.HttpContext.Response.Write("<h1>" + resultType + "</h1>" + "</br></br>");
            filterContext.HttpContext.Response.Write("OnActionExecuted</br><br />");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuted</br><br />");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuting</br><br />");
        }
    }
}