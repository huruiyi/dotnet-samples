using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    internal class ReflectionClass1
    {
        public ReflectionClass1()
        {
            Console.WriteLine("public ReflectionClass1()");
        }

        static ReflectionClass1()
        {
            Console.WriteLine("static ReflectionClass1()");
        }

        public ReflectionClass1(int i)
        {
            Console.WriteLine("public ReflectionClass1(int i)");
        }
    }
}