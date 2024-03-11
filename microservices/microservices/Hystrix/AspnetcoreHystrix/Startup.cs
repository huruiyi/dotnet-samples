using AspectCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace aspnetcorehystrix
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // services.AddSingleton<Person>();
            RegisterServices(this.GetType().Assembly, services);
            return services.BuildAspectCoreServiceProvider();
        }

        private static void RegisterServices(Assembly asm, IServiceCollection services)
        {
            foreach (Type type in asm.GetExportedTypes())
            {
                bool hasHystrixCommandAttribute = type.GetMethods().Any(m => m.GetCustomAttribute(typeof(HystrixCommandAttribute)) != null);
                if (hasHystrixCommandAttribute)
                {
                    services.AddSingleton(type);
                }
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}