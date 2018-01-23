using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConApp
{
    public class _AThreadPool
    {
        public static void Test()
        {
            ThreadPool.QueueUserWorkItem(ShowData, 10);
            ThreadPool.QueueUserWorkItem(ShowData, 30);
            Parallel.For(0, 20, (index) =>
            {
                Console.WriteLine(index.ToString());
            });
        }

        public static void ShowData(object numObj)
        {
            int num = (int)numObj;
            Console.WriteLine(DateTime.Now.ToString());

            for (int i = num - 1; i >= 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}