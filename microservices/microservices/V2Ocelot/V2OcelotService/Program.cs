using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace V2OcelotService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().ConfigureAppConfiguration((hostingContext, builder) =>
            {
                builder.AddJsonFile("Ocelot.json", false, true);
            }).UseUrls("http://127.0.0.1:9501").Build().Run();
        }
    }
}