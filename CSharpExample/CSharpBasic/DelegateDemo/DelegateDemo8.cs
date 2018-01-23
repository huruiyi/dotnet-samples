using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

        private static int AddStatic(int a, int b)
        {
            Console.WriteLine("AddStatic 执行了...、" + Thread.CurrentThread.ManagedThreadId + "\r\n");

            Thread.Sleep(3000);

            return a + b;
        }
        public void Invoke()
        {
            DelMath del1 = new DelMath(Add);
            int Sum = del1(12, 13);
            Console.WriteLine(Sum);

            DelMath del2 = Sub;
            Console.WriteLine(del2(13, 11));

            DelMath del3 =
                delegate(int i1, int i2)
                {
                    return i1 / i2;
                };
            Console.WriteLine(del3(12, 3));
            DelMath del4 = (a, b) => a + b;
            Console.WriteLine(del4(123, 456));

            Func<int, int> delFunc1 = delegate (int a)
            {
                return ++a;
            };
            Func<int, int> delFunc2 = a => ++a;

            DelMath delLambda0 = delegate (int i, int i1) { return i + i1; };
            delLambda0(3, 2);

            DelMath delLambda1 = (i, i1) => { return i + i1; };
            delLambda1(3, 2);

            DelMath delLambda2 = (i, i1) => i + i1;
            delLambda2(3, 2);

            Console.WriteLine(" 主线程是：{0}", Thread.CurrentThread.ManagedThreadId);

            DelMath myDel = new DelMath(AddStatic);

            //myDel(1,3)
            IAsyncResult delResult = myDel.BeginInvoke(3, 4, null, 2);

            while (!delResult.IsCompleted)
            {
                //主线程干其他事
            }
            int addResult = myDel.EndInvoke(delResult);
            Console.WriteLine("主线程获得结果是：{0}", addResult);

            myDelMath1 mdm = delegate (int a, int b, int c)
            {
                return a + b + c;
            };
            Console.WriteLine(mdm(12, 13, 16));
        }
    }
}