using AspectCore.DynamicProxy;
using System;

namespace InterceptorDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProxyGeneratorBuilder proxyGeneratorBuilder = new ProxyGeneratorBuilder();
            using (IProxyGenerator proxyGenerator = proxyGeneratorBuilder.Build())
            {
                Person p = proxyGenerator.CreateClassProxy<Person>();
                //注入
                p.Say("rupeng.com");
                Console.WriteLine(p.GetType());
                Console.WriteLine(p.GetType().BaseType);
            }
            Console.ReadKey();
        }
    }
}