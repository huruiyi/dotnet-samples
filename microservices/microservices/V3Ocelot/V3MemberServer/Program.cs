using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace V3MemberServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseUrls("http://127.0.0.1:6008").Build().Run();
        }
    }
}