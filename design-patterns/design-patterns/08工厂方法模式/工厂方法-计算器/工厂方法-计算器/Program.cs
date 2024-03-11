using System;

namespace 工厂方法_计算器
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IFactory operFactory = new AddFactory();
            Operation oper = operFactory.CreateOperation();
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();

            Console.WriteLine(result);

            Console.Read();
        }
    }
}