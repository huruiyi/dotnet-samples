using System.Web.Mvc;

namespace MVC.Sample.Fliters._3Result
{
    public class CusFilterAttributeIResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuted</br>");

            //  filterContext.Result as ContentResult
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuting</br>");
        }
    }
}