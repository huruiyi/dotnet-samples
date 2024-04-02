using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;

namespace V3OcelotService
{
    public class Startup
    {
        /*
         *  http://127.0.0.1:9500/connect/token
         *  Post
         *      Body:
                    client_id:clientPC1
                    client_secret:123321
                    grant_type:password
                    username:yzk
                    password:123
           Response
         * {
            "access_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6ImE0N2VjM2M4NTdlYzEwNjJmNWZjZjAzODg4MmE2ZDFjIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1MzAzODAzMDIsImV4cCI6MTUzMDM4MzkwMiwiaXNzIjoiaHR0cDovLzEyNy4wLjAuMTo5NTAwIiwiYXVkIjpbImh0dHA6Ly8xMjcuMC4wLjE6OTUwMC9yZXNvdXJjZXMiLCJNc2dBUEkiLCJQcm9kdWN0QVBJIl0sImNsaWVudF9pZCI6ImNsaWVudFBDMSIsInNjb3BlIjpbIk1zZ0FQSSIsIlByb2R1Y3RBUEkiXX0.HvvG2DBBUc1F0F7X_zT2kMBw0iaHs84hWPPeUYXpkYk-sRrmX7wLasRVxwvMeyXvN3pB7SGu3Pg-5BXCKB13N5ceEJ3pAyRvG05q-MHMoSyXabikGwiRShLfcKwflaQYPXhoVX3-24-3hQXiUfn-7I8P-9cjkQAkhajz6XqrJarKfNwW5Jkb_zfcfsbD3MUemzRpwcSQqnhuG8M43ohnD1JffmrIwPfVsqUIM5BPFOb92jnLLG9b1oij2HGpSwHCMRdY1DUADNjy7GwwyUnoEkhR3zD_3U6G_IWHiPBogx3Y7Ynn7368qTSknUK8QMdpYOpHNrQusBidNJLElPbatg",
            "expires_in": 3600,
            "token_type": "Bearer"
           }
         *http://127.0.0.1:9501/ProductService/Product
         *  访问受限资源方法
         *      Headers
         *           Authorization: Bearer access_token
         */
        public void ConfigureServices(IServiceCollection services)
        {
            //指定Identity Server的信息
            void IsaOptMsg(IdentityServerAuthenticationOptions o)
            {
                o.Authority = "http://127.0.0.1:9500";
                o.ApiName = "MsgAPI"; //要连接的应用的名字
                o.RequireHttpsMetadata = false;
                o.SupportedTokens = SupportedTokens.Both;
                o.ApiSecret = "123321"; //秘钥
            }

            Action<IdentityServerAuthenticationOptions> isaOptProduct = o =>
            {
                o.Authority = "http://127.0.0.1:9500";
                o.ApiName = "ProductAPI";//要连接的应用的名字
                o.RequireHttpsMetadata = false;
                o.SupportedTokens = SupportedTokens.Both;
                o.ApiSecret = "123321";//秘钥
            };
            //对配置文件中使用ChatKey配置了AuthenticationProviderKey=MsgKey
            //的路由规则使用如下的验证方式
            services.AddAuthentication()
                .AddIdentityServerAuthentication("MsgKey", IsaOptMsg)
                .AddIdentityServerAuthentication("ProductKey", isaOptProduct);
            services.AddOcelot();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOcelot().Wait();
        }
    }
}