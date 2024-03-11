using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace V2ProductService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            //string ip = config["ip"];
            string port = config["port"];

            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseUrls($"http://127.0.0.1:{port}").Build().Run();
        }
    }
}