using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace OcelotServer01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args).UseStartup<Startup>()
           .ConfigureAppConfiguration(conf =>
           {
               conf.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
           }).Build();
    }
}