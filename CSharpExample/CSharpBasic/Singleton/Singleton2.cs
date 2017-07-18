using System;

namespace Singleton
{
    public class Singleton2
    {
        private Singleton2()
        {
        }

        private static readonly Singleton2 _instance = new Singleton2();

        //线程不安全
        public static Singleton2 GetInstance()
        {
            Console.Write(DateTime.Now.ToString("MMddhhmmss") + "\t");
            return _instance;
        }
    }
}