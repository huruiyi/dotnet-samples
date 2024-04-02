using System;

namespace 适配器模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Target target = new Adapter();
            target.Request();

            Console.Read();
        }
    }

    internal class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("普通请求");
        }
    }

    internal class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("特殊请求");
        }
    }

    internal class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}