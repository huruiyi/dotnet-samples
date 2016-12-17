using System;
using System.Threading;

namespace 代码集合
{
    internal class Demo2 : IExample
    {
        public void Invoke()
        {
            Console.WriteLine("这是main thread。" + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(ShowMsg, "fuck" + i);
            }

            Console.WriteLine("主线程执行完成....");
        }

        public static void ShowMsg(Object oje)
        {
            Console.Write("线程池\t" + oje + Thread.CurrentThread.ManagedThreadId + "\n");
            Thread.Sleep(10);
        }
    }
}