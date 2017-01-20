using System;

namespace ConApp.Model
{
    public class ReflectionClass1
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