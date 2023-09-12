using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApi.OAuth.Startup))]

namespace WebApi.OAuth
{
    public partial class Startup
    {
        /**
         *   Enable-Migrations 
         *   Add-Migration Init
         *   Update-Database
         */
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
