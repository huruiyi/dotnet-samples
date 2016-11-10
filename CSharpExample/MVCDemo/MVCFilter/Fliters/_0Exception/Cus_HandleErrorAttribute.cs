using System.Web.Mvc;

namespace MVCFilter.Fliters._0Exception
{
    public class Cus_HandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}