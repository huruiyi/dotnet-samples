using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace V1OcelotService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseUrls("http://127.0.0.1:8888")
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    builder.AddJsonFile("Ocelot.json", false, true);
                }).Build().Run();
        }
    }
}