using System.ComponentModel.Composition;
using System.Web.Mvc;
using WebApp.Infrastructure;

namespace WebApp.Controllers
{
    public class LogController : Controller
    {
        private ILogger _logger;

        public LogController() :
            this(new TraceLogger())
        {
        }

        public LogController([Import("myTraceLogger")]ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.Write("LogController: Executing the Index() action method.");
            return View();
        }
    }
}