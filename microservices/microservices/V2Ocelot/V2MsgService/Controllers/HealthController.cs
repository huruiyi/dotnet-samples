using Microsoft.AspNetCore.Mvc;
using System;

namespace V2MsgService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("健康检查" + DateTime.Now);
            return Content("ok");
        }
    }
}