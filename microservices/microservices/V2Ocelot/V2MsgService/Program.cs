using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace V2MsgService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            //String ip = config["ip"];
            String port = config["port"];

            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseUrls($"http://127.0.0.1:{port}").Build().Run();
        }
    }
}