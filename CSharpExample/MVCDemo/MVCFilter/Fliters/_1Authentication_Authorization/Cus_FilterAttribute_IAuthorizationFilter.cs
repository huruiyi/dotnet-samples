using System.Web.Mvc;

namespace MVCFilter.Fliters._1Authentication_Authorization
{
    public class Cus_FilterAttribute_IAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["CurrentUser"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string actionName = filterContext.ActionDescriptor.ActionName;
            }
        }
    }
}