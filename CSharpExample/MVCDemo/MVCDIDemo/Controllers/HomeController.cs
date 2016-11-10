using MVCDIDemo.Components;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace MVCDIDemo.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private ILogger _logger;

        public HomeController()
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        [ImportingConstructor]
        public HomeController(ILogger logger)
        {
            _logger = logger;
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        public ActionResult Index()
        {
            if (_logger != null)
            {
                return Content("我好");
            }
            else
            {
                return Content("你好");
            }
        }
    }
}