using RestTemplateCore;
using System;
using System.Net.Http;

namespace RestTemplateClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ReadKey();
        }

        private static void Demo1()
        {
            using (HttpClient http = new HttpClient())
            {
                RestTemplate rest = new RestTemplate(http) { ConsulServerUrl = "http://127.0.0.1:8500" };
                SendSms sms = new SendSms
                {
                    msg = "您好，欢迎",
                    phoneNum = "189189"
                };
                var resp = rest.PostAsync("http://msgservice/api/SMS/Send_MI", sms).Result;
                Console.WriteLine(resp.StatusCode);
            }
        }

        private static void Demo2()
        {
            using (HttpClient http = new HttpClient())
            {
                RestTemplate rest = new RestTemplate(http)
                {
                    ConsulServerUrl = "http://127.0.0.1:8500"
                };

                var res = rest.GetForEntityAsync<Product[]>("http://ProductService/api/Product").Result;
                Console.WriteLine(res.StatusCode);
                foreach (var p in res.Body)
                {
                    Console.WriteLine(p.Id + p.Name);
                }
            }
        }

        private static void Demo3()
        {
            using (HttpClient http = new HttpClient())
            {
                RestTemplate rest = new RestTemplate(http)
                {
                    ConsulServerUrl = "http://127.0.0.1:8500"
                };

                var res = rest.GetForEntityAsync<Product>("http://ProductService/api/Product/1").Result;
                Console.WriteLine(res.StatusCode);
                Console.WriteLine(res.Body.Name);
            }
        }
    }

    internal class SendSms
    {
        public String phoneNum { get; set; }
        public String msg { get; set; }
    }

    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}