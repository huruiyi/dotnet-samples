using System.Web.Mvc;

namespace MVC.Sample.Fliters._0Exception
{
    public class Cus_HandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}