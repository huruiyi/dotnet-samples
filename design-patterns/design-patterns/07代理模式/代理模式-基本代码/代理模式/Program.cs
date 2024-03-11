using System;

namespace 代理模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();

            Console.Read();
        }
    }

    internal abstract class Subject
    {
        public abstract void Request();
    }

    internal class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("真实的请求");
        }
    }

    internal class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }
}