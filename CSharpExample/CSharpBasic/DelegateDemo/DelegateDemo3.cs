using System;

namespace DelegateDemo
{
    internal class DelegateDemo3 : IDelegateDemo
    {
        private static void PrintHelloWord(Func<string, object> sayHello)
        {
            const string name = "John";
            object content = sayHello(name);
            Console.WriteLine(content);
        }

        private static object ChineseSayHello(string to)
        {
            Console.WriteLine("1");
            return string.Format("{0},吃了没！", to);
        }

        private static object EnglishSayHello(string to)
        {
            Console.WriteLine("2");
            return string.Format("How do you do,{0}", to);
        }

        public void Invoke()
        {
            Func<string, object> sayHello = ChineseSayHello;

            sayHello += EnglishSayHello;
            PrintHelloWord(sayHello);
        }
    }
}