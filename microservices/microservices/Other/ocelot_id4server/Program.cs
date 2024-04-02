using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ocelot_id4server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>()
            .ConfigureAppConfiguration((hostingContext, builder) =>
            {
                builder
                .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                .AddJsonFile("Ocelot.json")
                .AddEnvironmentVariables();
            }).Build();
    }
}