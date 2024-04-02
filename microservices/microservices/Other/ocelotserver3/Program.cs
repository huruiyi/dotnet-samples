using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ocelotserver3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>()
                .UseUrls("http://127.0.0.1:5000")
                .ConfigureAppConfiguration(conf =>
                {
                    conf.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
                }).Build().Run();
        }
    }
}