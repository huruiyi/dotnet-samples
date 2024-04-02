using IdentityServer4.Models;
using System.Collections.Generic;

namespace ID4.IdServer
{
    public class Config
    {
        /// <summary>
        /// 返回应用列表
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> resources = new List<ApiResource>
            {
                new ApiResource("chatapi", "我的聊天软件"),
                new ApiResource("rpandroidapp", "如鹏安卓app"),
                new ApiResource("bdxcx", "百度小程序")
            };
            return resources;
        }

        /// <summary>
        /// 返回账号列表
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            List<Client> clients = new List<Client>
            {
                new Client
                {
                    ClientId = "yzk", //用户名
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("123321".Sha256()) //秘钥
                    },
                    AllowedScopes = {"chatapi", "bdxcx"} //这个账号支持访问哪些应用
                }
            };
            return clients;
        }
    }
}