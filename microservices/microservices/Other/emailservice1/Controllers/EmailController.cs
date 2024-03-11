using Microsoft.AspNetCore.Mvc;
using System;

namespace emailservice1.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        [HttpGet("Send")]
        public bool Send(string msg)
        {
            Console.WriteLine("发送邮件" + msg);
            return true;
        }

        [HttpGet("Receive")]
        public bool Receive(string msg)
        {
            Console.WriteLine("接收邮件" + msg);
            return true;
        }
    }
}