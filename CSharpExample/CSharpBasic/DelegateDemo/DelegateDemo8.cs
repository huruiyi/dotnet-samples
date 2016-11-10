using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateDemo
{
    internal class DelegateDemo8 : IDelegateDemo
    {
        public delegate int DelMath(int a, int b);

        public delegate int myDelMath1(int a, int b, int c);

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }

        public static int Mul(int a, int b)
        {
            return a * b;
        }

        public void Invoke()
        {
            DelMath del1 = new DelMath(Add);
            int Sum = del1(12, 13);
            Console.WriteLine(Sum);

            DelMath del2 = Sub;
            Console.WriteLine(del2(13, 11));

            DelMath del3 =
                delegate (int i1, int i2)
                {
                    return i1 / i2;
                };
            Console.WriteLine(del3(12, 3));
            DelMath del4 = (a, b) => a + b;
            Console.WriteLine(del4(123, 456));
            myDelMath1 mdm = delegate (int a, int b, int c)
            {
                return a + b + c;
            };
            Console.WriteLine(mdm(12, 13, 16));
        }
    }
}