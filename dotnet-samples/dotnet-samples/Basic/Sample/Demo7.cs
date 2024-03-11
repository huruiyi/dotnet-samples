using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BasicSample
{
    internal class Demo7 : IExample
    {
        public void Invoke()
        {
            MethodLock();
            for (int i = 100; i < 1000; i++)
            {
                Thread t = new Thread(() =>
                {
                    Console.Write(i + "\t");
                });
                t.Start();
            }
        }

        protected int forNum = 0;

        public void PrintNum(int num)
        {
            Console.WriteLine(Thread.CurrentThread.Name + ",哈哈哈~~~");
            Console.WriteLine(num);
        }

        //同步方法 特性
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void MethodLock()
        {
            for (; forNum < 100; forNum++)
            {
                PrintNum(forNum);
            }
        }
    }
}