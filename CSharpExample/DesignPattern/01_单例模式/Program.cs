using System;
using System.Threading;

namespace _01_单例模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    Person p = new Person();

            //    Person p1 = new Person();
            //}

            //Person p = new Person(

            //for (int i = 0; i < 1000; i++)
            //{
            //    Person p = Person.GetInstance();
            //}

            for (int i = 0; i < 1000; i++)
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    Person p = Person.GetInstance();
                    //Singleton1 p = Singleton1.GetInstance();
                    //Singleton2 s2 = Singleton2.GetInstance();
                }));
                t.Start();
            }
            Console.WriteLine("ok");
            Console.Read();
        }
    }

    public class Singleton2
    {
        private Singleton2()
        {
            Console.WriteLine(".");
        }

        private static readonly Singleton2 _instance = new Singleton2();

        //线程不安全
        public static Singleton2 GetInstance()
        {
            Console.WriteLine("创建成功" + DateTime.Now.ToString("yyyy-MM-dd:hhmmss"));
            return _instance;
        }
    }

    public class Singleton1
    {
        private Singleton1()
        {
            Console.WriteLine(".");
        }

        private static Singleton1 _instance;

        private static readonly object syn = new object();

        public static Singleton1 GetInstance()
        {
            if (_instance == null)
            {
                lock (syn)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton1();
                        Console.WriteLine("创建成功" + DateTime.Now.ToString("yyyy-MM-dd:hhmmss"));
                    }
                }
            }
            return _instance;
        }
    }

    public class Person
    {
        //把类的构造函数的访问修饰符改为private
        private Person()
        {
            Console.WriteLine(".");
        }

        private static Person _instance = null;

        public static Person GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Person();
                Console.WriteLine("创建成功" + DateTime.Now.ToString("yyyy-MM-dd:hhmmss"));
            }
            return _instance;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}