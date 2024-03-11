using AspectCore.DynamicProxy;
using System;

namespace hystrixtest1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                ProxyGeneratorBuilder proxyGeneratorBuilder = new ProxyGeneratorBuilder();
                using (IProxyGenerator proxyGenerator = proxyGeneratorBuilder.Build())
                {
                    Person p = proxyGenerator.CreateClassProxy<Person>();
                    Console.WriteLine(p.HelloAsync("yzk").Result);
                    //Console.WriteLine(p.Add(1, 2));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}