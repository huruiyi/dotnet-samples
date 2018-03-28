using System.Web.Mvc;

namespace MVC.Sample.Fliters._0Exception
{
    public class Cus_ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string exception = filterContext.Exception.StackTrace;
        }
    }
}