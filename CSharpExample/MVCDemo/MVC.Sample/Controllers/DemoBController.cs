using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class DemoBController : Controller
    {
        // GET: DemoB
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public new void Execute(System.Web.Routing.RequestContext requestContext)
        {
            //action名称是以key/value保存的
            string actionName = requestContext.RouteData.Values["action"].ToString().ToLower();
            switch (actionName)
            {
                case "index":
                    requestContext.HttpContext.Response.Write("我来自OldProduct/Index");
                    break;

                default:
                    requestContext.HttpContext.Response.Write("我来自OleProduct/" + actionName);
                    break;
            }
        }
    }
}