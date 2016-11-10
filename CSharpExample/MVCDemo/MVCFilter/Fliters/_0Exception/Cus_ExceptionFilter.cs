using System.Web.Mvc;

namespace MVCFilter.Fliters._0Exception
{
    public class Cus_ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string exception = filterContext.Exception.StackTrace;
        }
    }
}