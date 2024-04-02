using Microsoft.AspNetCore.Mvc;
using System;

namespace OcelotServer01.Api.Controllers
{
    //set ASPNETCORE_URLS = http://127.0.0.1:5002

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