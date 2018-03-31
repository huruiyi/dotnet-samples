using MVC.Sample.Models;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class CusIocController : Controller
    {
        public IMathService MathService;

        public CusIocController(IMathService mathService)
        {
            MathService = mathService;
        }

        // GET: CusIoc
        public ActionResult Index()
        {
            return View();
        }
    }
}