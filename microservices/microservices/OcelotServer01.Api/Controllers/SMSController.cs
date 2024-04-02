using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace OcelotServer01.Api.Controllers
{
    //set ASPNETCORE_URLS = http://127.0.0.1:5001
    [Produces("application/json")]
    [Route("api/[controller]")]

    //[Route("api/SMS")]
    public class SmsController : Controller
    {
        //"UpstreamPathTemplate": "/sms/{url}",  不适配/api/sms?msg=Hello
        //http://localhost:21422/api/sms?msg=Hello
        public string SendMsg(string msg)
        {
            string message = "SendMsg:发送短信:" + msg;
            Console.WriteLine(message);

            return message;
        }

        // Error
        //public string SendMsgs(string msg)
        //{
        //    string message = "SendMsgs:发送短信:" + msg;
        //    Console.WriteLine(message);

        //    return message;
        //}

        //OcelotServer01: http://localhost:806/sms/ReceiveMsg?msg=12345678910
        [HttpGet("Send")]
        public IEnumerable<string> Send(string msg)
        {
            string message = "SendMsg:发送短信:" + msg;
            Console.WriteLine(message);

            string value = Request.Headers["X-Hello"];
            Console.WriteLine($"x-hello={value}");
            Console.WriteLine("发送短信" + msg);
            return new string[] { HttpContext.Request.Path, HttpContext.Request.Host.Value };
        }

        //http://localhost:21422/api/sms/ReceiveMsg?msg=Hello
        // GET api/values
        [HttpGet("ReceiveMsg")]
        public bool ReceiveMsg(string msg)
        {
            Console.WriteLine("收到回复短信:" + msg);
            return true;
        }
    }
}