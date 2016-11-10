using System;

namespace DelegateDemo
{
    internal class DelegateDemo1 : IDelegateDemo
    {
        public delegate void Sayhello(string name);

        private static void Print(Sayhello sayHello)
        {
            sayHello("Nation");
        }

        private static void ChineseSayHello(object name)
        {
            Console.WriteLine("{0}:中国", name);
        }

        private static void EnglishSayHello(object name)
        {
            Console.WriteLine("{0}:英国", name);
        }

        private static void JapaneseSayHello(object name)
        {
            Console.WriteLine("{0}:日本", name);
        }

        private static void PrintHelloWord(Func<string, object> sayHello)
        {
            const string name = "John";
            object content = sayHello(name);
            Console.WriteLine(content);
        }

        public void Invoke()
        {
            Sayhello sayhello0 = new Sayhello(ChineseSayHello) + EnglishSayHello + JapaneseSayHello;
            sayhello0.Invoke("A");
            Print(sayhello0);

            Func<string, object> sayhello1 = param => string.Format("{0},吃了没！", param);
            Console.WriteLine(sayhello1("小红"));
            PrintHelloWord(sayhello1);

            Func<string, object> sayhello2 = delegate (string name)
            {
                Console.WriteLine("1");
                return string.Format("{0},吃了没！", name);
            };
            Console.WriteLine(sayhello2("小红"));
            PrintHelloWord(sayhello2);

            Func<string, object> sayHello2 = (str) => (string.Format("How do you do,{0}", str));
            PrintHelloWord(sayHello2);

            Func<string, object> sayHello22 = (str) => string.Format("How do you do,{0}", str);
            PrintHelloWord(sayHello22);

            Func<int, int, int> test1 = (a, b) => (a + b);
            test1.Invoke(1, 2);

            Func<int, int, int> test2 = (a, b) => { return a + b; };
            test2.Invoke(12, 13);

            Func<int, int, int> test3 = delegate (int a, int b) { return a + b; };
            test3.Invoke(14, 15);
        }
    }
}