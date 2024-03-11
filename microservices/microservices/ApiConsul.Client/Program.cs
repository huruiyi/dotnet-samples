using ApiConsul.Tools;
using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace ApiConsul.Client
{
    internal class Program
    {
        private static void Demo1()
        {
            // 负载均衡到每台服务器
            for (int i = 0; i < 10; i++)
            {
                RestTemplate rest = new RestTemplate("http://127.0.0.1:8500");
                ResponseEntity<string[]> resp = rest.GetForEntityAsync<string[]>("http://apiservice1/api/values").Result;
                Console.WriteLine(resp.StatusCode + "  " + string.Join(",", resp.Body));
                Thread.Sleep(1000);
            }
        }

        private static void Demo2()
        {
            using (var consulClient = new ConsulClient(c => c.Address = new Uri("http://127.0.0.1:8500")))
            {
                //获取consul中注册的所有的服务
                //Task<QueryResult<Dictionary<string, AgentService>>> services = consulClient.Agent.Services();

                Dictionary<string, AgentService> services = (consulClient.Agent.Services().Result).Response;

                foreach (var kv in services)
                {
                    Console.WriteLine($"key={kv.Key},{kv.Value.Address},{kv.Value.ID},{kv.Value.Service},{kv.Value.Port}");
                }

                //获取所有服务名字是"apiservice1"所有的服务
                var agentServices = services.Where(s => s.Value.Service.Equals("apiservice1", StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Value);
                //客户端负载均衡,注入负载均衡策略
                //随机选出一台服务（用自从系统启动以来的毫秒数和服务的个数取模）
                //根据当前TickCount对服务器个数取模，“随机”取一个机器出来，避免“轮询”的负载均衡策略需要计数加锁问题
                var agentService = agentServices.ElementAt(Environment.TickCount % agentServices.Count());
                Console.WriteLine($"{agentService.Address + "" + agentService.Port},{agentService.ID},{agentService.Service} ");
            }
        }

        private static void Demo3()
        {
            using (var consul = new ConsulClient(c =>
            {
                c.Address = new Uri("http://127.0.0.1:8500");
            }))
            {
                var services = consul.Agent.Services().Result.Response.Values.Where(item => item.Service.Equals("MsgService", StringComparison.OrdinalIgnoreCase));

                var agentServices = services as AgentService[] ?? services.ToArray();

                foreach (var item in agentServices)
                {
                    Console.WriteLine($"id={item.ID},service={item.Service},addr={item.Address},port={item.Port}");
                }

                //客户端负载均衡
                Random rand = new Random();
                int index = rand.Next(agentServices.Count());//[0,services.Count())
                var s = agentServices.ElementAt(index);
                Console.WriteLine($"index={index},id={s.ID},service={s.Service},addr={s.Address},port={s.Port}");
                using (HttpClient http = new HttpClient())
                using (var httpContent = new StringContent("{phoneNum:'119',msg:'help'}", Encoding.UTF8, "application/json"))
                {
                    var r = http.PostAsync($"http://{s.Address}:{s.Port}/api/SMS/Send_LX", httpContent).Result;
                    Console.WriteLine(r.StatusCode);
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}