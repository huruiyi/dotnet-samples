using System;

namespace DelegateDemo
{
    internal class DelegateDemo2 : IDelegateDemo
    {
        private static void PrintHelloWord(Func<string, object> sayHello)
        {
            const string name = "John";
            object result = sayHello(name);
            Console.WriteLine(result);
        }

        private static string ChineseSayHello(object name)
        {
            Console.WriteLine("中国人说话");
            return string.Format("{0},吃饭了没", name);
        }

        private static string EnglishSayHello(object name)
        {
            Console.WriteLine("英国人说话");
            return string.Format("Hello,{0}", name);
        }

        private static string JapaneseSayHello(object name)
        {
            Console.WriteLine("日本人说话");
            return string.Format("moxi moxi,{0}", name);
        }

        private static int Add(int a, int b)
        {
            Console.WriteLine("{0}+{1}={2}", a, b, a + b);
            return a + b;
        }

        private static int Sub(int a, int b)
        {
            Console.WriteLine("{0}-{1}={2}", a, b, a - b);
            return a - b;
        }

        private static void PrintHelloWordInInt(Func<int, string> sayHello)
        {
            const int age = 18;
            string result = sayHello(age);
            Console.WriteLine(result);
        }

        private static string ChineseSayHelloInInt(int age)
        {
            return string.Format("中国人说,我{0}岁了", age);
        }

        private static string EnglishSayHelloInInt(int age)
        {
            return string.Format("英国人说,我{0}岁了", age);
        }

        private static string JapaneseSayHelloInInt(int age)
        {
            return string.Format("日本人说,我{0}岁了", age);
        }

        public void Invoke()
        {
            Func<string, object> sayhello = ChineseSayHello;
            sayhello += EnglishSayHello;
            sayhello += JapaneseSayHello;
            sayhello("AAA");
            PrintHelloWord(sayhello);

            Func<int, int, string> oper = (a, b) => "两数和是:" + (a + b);
            Console.WriteLine(oper(12, 13));
            Func<int, int, int> ope = Add;
            ope += Sub;
            ope(10, 2);

            Func<int, string> sayhelloFun = ChineseSayHelloInInt;
            sayhelloFun += EnglishSayHelloInInt;
            sayhelloFun += JapaneseSayHelloInInt;
            PrintHelloWordInInt(sayhelloFun);
        }
    }
}