using System;
using System.Threading;

namespace 代码集合
{
    internal class Demo3 : IExample
    {
        public void Invoke()
        {
            Func<bool> ascyRun = ProcessCount;
            IAsyncResult reslu = ascyRun.BeginInvoke(MyAsyncCallback, ascyRun);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);

                Console.WriteLine("End。。。。。。。。");
            }
        }

        public static void MyAsyncCallback(IAsyncResult ar)
        {
            Func<bool> pc = (Func<bool>)ar.AsyncState;
            var endInvoke = pc.EndInvoke(ar);
            if (endInvoke)
            {
                Console.WriteLine("处理完成。。" + endInvoke);
            }
            else
            {
                Console.WriteLine("处理失败。。" + endInvoke);
            }
        }

        private static bool ProcessCount()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + "\t");
                Thread.Sleep(100);
            }
            return true;
        }
    }
}