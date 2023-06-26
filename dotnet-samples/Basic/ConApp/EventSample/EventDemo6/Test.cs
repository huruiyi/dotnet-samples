using System;
using System.Threading;

namespace ConApp.EventSample.EventDemo6
{
    public class Test
    {
        public static void Demo()
        {
            var test = new Heater();

            #region 若多次添加同一个事件处理函数时，触发时处理函数是否也会多次触发？

            test.OnBoiled += TestOnBoiled;
            test.OnBoiled += TestOnBoiled;
            test.Begin();

            #endregion 若多次添加同一个事件处理函数时，触发时处理函数是否也会多次触发？

            #region 若添加了一个事件处理函数，却执行了两次或多次”取消事件“，是否会报错？

            //test.OnBoiled += TestOnBoiled;
            //test.OnBoiled += TestOnBoiled;
            //test.OnBoiled -= TestOnBoiled;
            //test.Begin();

            #endregion 若添加了一个事件处理函数，却执行了两次或多次”取消事件“，是否会报错？

            #region 如何认定两个事件处理函数是一样的？ 如果是匿名函数呢？

            //test.OnBoiled += (s, e) => Console.WriteLine("加热完成事件被调用");
            //test.OnBoiled -= (s, e) => Console.WriteLine("加热完成事件被调用");
            //test.Begin();

            #endregion 如何认定两个事件处理函数是一样的？ 如果是匿名函数呢？

            #region 如果不手动删除事件函数，系统会帮我们回收吗？(更新引用)

            // test.OnBoiled += (s, e) => Console.WriteLine("加热完成事件被调用");
            //test=new Heater();
            //test.Begin();

            #endregion 如果不手动删除事件函数，系统会帮我们回收吗？(更新引用)

            #region 如果不手动删除事件函数，系统会帮我们回收吗？(没有更新引用)

            //test.OnBoiled += (s, e) => Console.WriteLine("加热完成事件被调用");
            //var heaters = new List<Heater>() { test, test };
            //heaters.Clear();
            //test.Begin();
            //test = null;
            //GC.Collect();  //不论你加不加这句话，事件都会被执行

            #endregion 如果不手动删除事件函数，系统会帮我们回收吗？(没有更新引用)

            #region 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(采用新加线程的做法)

            //test.OnBoiled += (s, e) =>
            //    {
            //        var newThread = new Thread(
            //            new ThreadStart(
            //                () =>
            //                {
            //                    Thread.Sleep(2000); //模拟长时间操作
            //                    Console.WriteLine("总算把热好的水加到了暖瓶里");
            //                }));
            //        newThread.Start();

            //    };

            //test.Begin();

            #endregion 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(采用新加线程的做法)

            #region 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(采用线程池的做法)

            //var mainThread = Thread.CurrentThread;
            //test.OnBoiled += (s, e) =>
            //    {
            //        ThreadPool.QueueUserWorkItem((d) =>
            //            {
            //                Thread.Sleep(2000); //模拟长时间操作
            //                Console.WriteLine("总算把热好的水加到了暖瓶里");
            //                if (Thread.CurrentThread != mainThread)
            //                {
            //                    Console.WriteLine("两者执行的是不同的线程");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("两者执行的是相同的线程");
            //                }

            //            });
            //    };

            //test.Begin();

            #endregion 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(采用线程池的做法)

            #region 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(构造函数在另一个线程)

            //var mainThread = Thread.CurrentThread;

            //ThreadPool.QueueUserWorkItem((d) =>
            //    {
            //        test.OnBoiled += (s, e) =>
            //            {
            //                if(Thread.CurrentThread == mainThread )
            //                Console.WriteLine(Thread.CurrentThread != mainThread ? "两者执行的是不同的线程" : "两者执行的是相同的线程");
            //            };
            //    });

            //test.Begin();

            #endregion 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(构造函数在另一个线程)

            #region 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(订阅函数在另一个线程)

            var mainThread = Thread.CurrentThread;
            ThreadPool.QueueUserWorkItem((d) =>
            {
                var bThread = Thread.CurrentThread;
                test.OnBoiled += (s, e) =>
                {
                    if (Thread.CurrentThread == mainThread)
                        Console.WriteLine("事件在主线程中执行");
                    else if (bThread == Thread.CurrentThread)
                    {
                        Console.WriteLine("事件在订阅事件的线程B中执行");
                    }
                    else
                    {
                        Console.WriteLine("事件在第三个线程中执行");
                    }
                };
            });

            test.Begin();

            #endregion 在多线程环境下，挂接事件时和对象创建所在的线程不同，那事件处理函数中的代码将在哪个线程中执行？(订阅函数在另一个线程)
        }

        private static void TestOnBoiled(object sender, EventArgs e)
        {
            Console.WriteLine("加热完成事件被调用");
        }
    }
}
