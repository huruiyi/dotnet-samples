using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using V3WebApp.Models;
using V3WebApp.Services;

namespace V3WebApp.Controllers
{
    public class HomeController : Controller
    {
        private SMSService smsService;

        public HomeController(SMSService smsService)
        {
            this.smsService = smsService;
        }

        //[HttpPost(nameof(SendSMS))]
        [HttpPost]
        public async Task<IActionResult> SendSMS()
        {
            await smsService.Send_MI("110", "help");
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}