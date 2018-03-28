using MVC.Sample.Controllers;
using MVC.Sample.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MVC.Sample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public MemberPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as MemberPrincipal; }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Clear();
            Exception exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            if (exception == null)
            {
                routeData.Values.Add("action", "Index");
            }
            else if (httpException == null)
            {
                routeData.Values.Add("action", "Index");
            }
            else
            {
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        routeData.Values.Add("action", "HttpError404");
                        break;

                    case 500:
                        routeData.Values.Add("action", "HttpError500");
                        break;

                    default:
                        routeData.Values.Add("action", "General");
                        break;
                }
            }
            routeData.Values.Add("error", exception.Message);
            Server.ClearError();
            IController errorController = new ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var serializer = new JavaScriptSerializer();
                var model = serializer.Deserialize<MemberInfo>(authTicket.UserData);
                var memberUser = new MemberPrincipal(authTicket.Name)
                {
                    MemberId = model.MemberId,
                    MemberName = model.MemberName,
                    MemberMobile = model.MemberMobile,
                    MemberEmail = model.MemberEmail,
                    MemberTrueName = model.MemberTrueName,
                    AllRoles = new List<string> { "Admin", "User" },
                    Role = model.Role
                };

                HttpContext.Current.User = memberUser;

                //FormsIdentity identity = new FormsIdentity(authTicket);
                //string[] roles = { memberUser.Role };
                //HttpContext.Current.User = new GenericPrincipal(identity, roles);

                bool isrole = HttpContext.Current.User.IsInRole(memberUser.Role);
            }
        }
    }
}