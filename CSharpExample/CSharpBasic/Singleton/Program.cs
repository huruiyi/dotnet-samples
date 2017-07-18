using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    SinglePerson p = SinglePerson.GetInstance();
                    Singleton1 p1 = Singleton1.GetInstance();
                    //Singleton2 s2 = Singleton2.GetInstance();
                });
            }

            Console.ReadKey();
        }
    }
}
