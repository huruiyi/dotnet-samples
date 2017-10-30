using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace NetCore.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>()
              .Build();

            host.Run();

            //BuildWebHost(args).Run();
        }

        //public static IWebHost BuildWebHost(string[] args)
        //    => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
    }
}