using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace MultThreadReviewConsole
{
    public delegate int AddDel(int a, int b);

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("主线程{0} 正在执行中....", Thread.CurrentThread.ManagedThreadId);

            #region 异步委托

            AddDel addDemo = AddFun;
            var ascResult = addDemo.BeginInvoke(1, 2, null, null);
            while (!ascResult.IsCompleted)
            {
                //主线程再干一些事情
            }

            // //此EndInvoke方法会阻塞当前线程。 直到 委托方法执行完毕后，并将返回值交给 result后，继续执行后面的代码
            int result = addDemo.EndInvoke(ascResult);

            //第二种： 使用 回调函数
            IAsyncResult ascResult2 = addDemo.BeginInvoke(1, 2, MyDelCallBakc, 3);

            Console.WriteLine("执行的结果是：{0}", result);
            Console.ReadKey();

            #endregion 异步委托

            #region 并行计算

            int[] sum = { 0 };

            object lck = new object();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(1, 1000000, i =>
                                    {
                                        lock (lck)
                                        {
                                            sum[0] += i;
                                        }
                                        Console.WriteLine("当前执行到 ：" + i + "@" + Thread.CurrentThread.ManagedThreadId);
                                        Thread.Sleep(1000);
                                    });
            sw.Stop();

            Console.WriteLine(sum[0] + "---" + sw.ElapsedMilliseconds);

            sum[0] = 0;

            sw.Reset();
            sw.Start();
            for (int i = 1; i < 1000000; i++)
            {
                sum[0] += i;
            }
            sw.Stop();

            Console.WriteLine(sum[0] + "---" + sw.ElapsedMilliseconds);

            #endregion 并行计算

            Console.WriteLine("主线程执行完毕。。。");

            Console.ReadKey();
        }

        //异步委托  执行完成了的回调函数
        public static void MyDelCallBakc(IAsyncResult result)
        {
            //Thread.CurrentThread;

            //把接口类型转换成实例类型
            AsyncResult aReuslt = (AsyncResult)result;

            //转换成我们自己的委托类型
            AddDel del = (AddDel)aReuslt.AsyncDelegate;

            //执行完成获取  执行的结果
            int addResult = del.EndInvoke(result);

            int state = (int)aReuslt.AsyncState;

            Console.WriteLine("异步完成的回调方法执行的结果是：{0} @{1}", addResult, Thread.CurrentThread.ManagedThreadId);
        }

        //委托回调方法
        private static int AddFun(int a, int b)
        {
            Console.WriteLine("只是工作线程跑着..{0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            return a + b;
        }

        private static void ShowMsg()
        {
            Console.WriteLine("工作线程跑着...{0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
        }
    }
}