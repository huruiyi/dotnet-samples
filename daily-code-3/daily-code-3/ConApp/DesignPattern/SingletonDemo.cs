using System;
using System.Threading.Tasks;

namespace ConApp.DesignPattern
{
    public class SingletonDemo
    {
        public class SinglePerson
        {
            private SinglePerson()
            {
            }

            private static SinglePerson _instance = null;

            public static SinglePerson GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new SinglePerson();
                    Console.WriteLine("创建成功" + DateTime.Now.ToString("yyyy-MM-dd:hhmmss"));
                }
                return _instance;
            }

            public string Name { get; set; }

            public string Email { get; set; }

            public int Age { get; set; }
        }

        public class Singleton1
        {
            private Singleton1()
            {
            }

            private volatile static Singleton1 _instance;

            private static readonly object syn = new object();

            public static Singleton1 Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (syn)
                        {
                            if (_instance == null)
                            {
                                _instance = new Singleton1();
                            }
                        }
                    }
                    return _instance;
                }
            }

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

        public class Singleton2
        {
            private Singleton2()
            {
            }

            private static readonly Singleton2 _instance = new Singleton2();

            public static Singleton2 GetInstance()
            {
                Console.WriteLine(DateTime.Now.ToString("MMddhhmmss"));
                return _instance;
            }
        }

        private static void Demo(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    SinglePerson p = SinglePerson.GetInstance();
                    Singleton1 p1 = Singleton1.GetInstance();
                    Singleton2 s2 = Singleton2.GetInstance();
                });
            }

            Console.ReadKey();
        }
    }
}