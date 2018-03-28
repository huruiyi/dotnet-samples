using System;
using System.Web;
using System.Web.Mvc;

namespace MVC.Sample.Fliters._1Authentication_Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Cus_AuthorizeAttribute_IAuthorizationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override object TypeId
        {
            get { return base.TypeId; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}