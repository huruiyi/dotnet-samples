using System;
using System.Threading;
using System.Threading.Tasks;

namespace 代码集合
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ReadKey();
        }

        private static void TaskDemo()
        {
            Task<string> task = new Task<string>(() =>
            {
                Console.WriteLine("当前线程是:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                return "shit";
            });

            task.Start();//通过线程池获取一个线程然后执行  回调方法
            task.Wait();
            task.Wait(5000);
            Console.WriteLine(task.Result);
        }
    }
}