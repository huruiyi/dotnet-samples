using Microsoft.AspNetCore.Mvc;

namespace ApiConsul.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}