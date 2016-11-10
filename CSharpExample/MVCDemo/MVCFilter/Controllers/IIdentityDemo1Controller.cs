using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Controllers
{
    public class IIdentityDemo1Controller : Controller
    {
        // GET: IIdentityDemo1
        public ActionResult Index()
        {
            HttpContext.User = new MyPrincipal1
            {
                Name = "User1",
                Role = "Admin",
                MemberId = "807776962",
                Midentity = new MyIdentity1
                {
                }
            };

            MyPrincipal1 ipr = HttpContext.User as MyPrincipal1;
            GenericIdentity g = new GenericIdentity(HttpContext.User.Identity.Name);
            HttpContext.User = ipr;
            return View();
        }
    }

    public class MyPrincipal1 : IPrincipal
    {
        public MyIdentity1 Midentity { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string MemberId { get; set; }

        public IIdentity Identity
        {
            get
            {
                return Midentity;
            }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    public class MyIdentity1 : IIdentity
    {
        public string AuthenticationType
        {
            get { return "Admin"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return "huruiyi"; }
        }
    }
}