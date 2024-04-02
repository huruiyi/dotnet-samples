using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ocelot_id4server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //想哪一台服务器报告“我是哪个应用”
            services.AddAuthentication()
            //对配置文件中使用ChatKey配置了AuthenticationProviderKey=ChatKey
            //的路由规则使用如下的验证方式
           .AddIdentityServerAuthentication("ChatKey", o =>
           {
               //IdentityService认证服务的地址
               o.Authority = "http://localhost:9500";
               o.ApiName = "chatapi";//要连接的应用的名字
               o.RequireHttpsMetadata = false;
               o.SupportedTokens = SupportedTokens.Both;
               o.ApiSecret = "123321";//秘钥
           });
            services.AddOcelot();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseOcelot().Wait();
        }
    }
}