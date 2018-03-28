using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MVC.Sample.Fliters._1Authentication_Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class Sys_Authorize_FilterAttribute_IAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        private static readonly char[] _splitParameter = new char[] { ',' };

        private readonly object _typeId = new object();

        private string _roles;

        private string[] _rolesSplit = new string[0];

        private string _users;

        private string[] _usersSplit = new string[0];

        public string Roles
        {
            get
            {
                return this._roles ?? string.Empty;
            }
            set
            {
                this._roles = value;
                this._rolesSplit = SplitString(value);
            }
        }

        public override object TypeId
        {
            get
            {
                return this._typeId;
            }
        }

        public string Users
        {
            get
            {
                return this._users ?? string.Empty;
            }
            set
            {
                this._users = value;
                this._usersSplit = SplitString(value);
            }
        }

        protected virtual bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            IPrincipal user = httpContext.User;
            return user.Identity.IsAuthenticated
                && (this._usersSplit.Length <= 0 || this._usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
                && (this._rolesSplit.Length <= 0 || this._rolesSplit.Any(new Func<string, bool>(user.IsInRole)));
        }

        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = this.OnCacheAuthorization(new HttpContextWrapper(context));
        }

        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
            {
                throw new InvalidOperationException("...........");
            }
            bool flag = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (flag)
            {
                return;
            }
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
                cache.SetProxyMaxAge(new TimeSpan(0L));
                cache.AddValidationCallback(new HttpCacheValidateHandler(this.CacheValidateHandler), null);
                return;
            }
            this.HandleUnauthorizedRequest(filterContext);
        }

        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

        protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            if (!this.AuthorizeCore(httpContext))
            {
                return HttpValidationStatus.IgnoreThisRequest;
            }
            return HttpValidationStatus.Valid;
        }

        internal static string[] SplitString(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return new string[0];
            }
            IEnumerable<string> source = from piece in original.Split(_splitParameter)
                                         let trimmed = piece.Trim()
                                         where !string.IsNullOrEmpty(trimmed)
                                         select trimmed;
            return source.ToArray<string>();
        }
    }
}