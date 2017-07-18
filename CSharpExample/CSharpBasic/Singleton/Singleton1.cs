using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Singleton1
    {
        private Singleton1()
        {
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
}
