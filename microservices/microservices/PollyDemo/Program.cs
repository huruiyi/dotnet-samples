using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Caching;
using Polly.Timeout;
using System;
using System.Threading;

namespace PollyDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Demo3();

            Console.ReadKey();
        }

        private static void Demo1()
        {
            try
            {
                ISyncPolicy policy = Policy.Handle<ArgumentException>(ex => ex.Message == "年龄参数错误").Fallback(() => Console.WriteLine("出错了"));
                policy.Execute(() =>
                {
                    //这里是可能会产生问题的业务系统代码
                    Console.WriteLine("开始任务");
                    //throw new ArgumentException("年龄参数错误");
                    throw new ArgumentException("xx年龄参数错误");
                    throw new Exception("haha");
                    Console.WriteLine("完成任务");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("未处理异常" + ex);
            }
        }

        private static void Demo2()
        {
            try
            {
                //ISyncPolicy policy = Policy.Handle<Exception>().WaitAndRetry(new TimeSpan[] { TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(2000) });
                //ISyncPolicy policy = Policy.Handle<Exception>().RetryForever( );
                ISyncPolicy policy = Policy.Handle<Exception>().Retry();
                //RetryForever();
                //Policy.Handle<Exception>().Retry
                //Policy.Handle<Exception>().RetryForever
                //Policy.Handle<Exception>().Fallback
                //Policy.Handle<Exception>().CircuitBreaker
                //Policy.Handle<Exception>().WaitAndRetry
                policy.Execute(() =>
                {
                    Console.WriteLine("开始任务");

                    //if (Environment.TickCount % 2 == 0)
                    if (DateTime.Now.Second % 5 != 0)
                    {
                        throw new Exception("出错");
                    }
                    Console.WriteLine("完成任务");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("未处理异常" + ex);
            }
        }

        private static void Demo3()
        {
            //连续出错6次之后熔断5秒(不会再去尝试执行业务代码）。
            ISyncPolicy policy = Policy.Handle<Exception>().CircuitBreaker(6, TimeSpan.FromSeconds(5));

            while (true)
            {
                Console.WriteLine("开始Execute");
                try
                {
                    policy.Execute(() =>
                    {
                        Console.WriteLine("开始任务");
                        throw new Exception("出错");
                        Console.WriteLine("完成任务");
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("execute出错" + ex.GetType() + ":" + ex.Message);
                }
                Thread.Sleep(1000);
            }
        }

        private static void Demo4()
        {
            try
            {
                ISyncPolicy policyException = Policy.Handle<TimeoutRejectedException>().Fallback(() => Console.WriteLine("fallback"));
                ISyncPolicy policytimeout = Policy.Timeout(2, Polly.Timeout.TimeoutStrategy.Pessimistic);
                //ISyncPolicy policy3 = policyException.Wrap(policytimeout);//
                ISyncPolicy policy3 = Policy.Wrap(policyException, policytimeout);
                policy3.Execute(() =>
                {
                    Console.WriteLine("开始任务");
                    Thread.Sleep(5000);
                    //throw new Exception();
                    Console.WriteLine("完成任务");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("未处理异常" + ex.GetType() + ":" + ex.Message);
            }
        }

        private static void Demo5()
        {
            // Polly5.9.0 和  Polly6.0.1差异
            IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
            ISyncCacheProvider memoryCacheProvider = new Polly.Caching.MemoryCache.MemoryCacheProvider(memoryCache);

            CachePolicy policy = Policy.Cache(memoryCacheProvider, TimeSpan.FromSeconds(5));
            Random rand = new Random();
            while (true)
            {
                int i = rand.Next(5);
                Console.WriteLine("产生" + i);
                var context = new Context("doublecache" + i);
                int result = policy.Execute(ctx =>
                {
                    Console.WriteLine("Execute计算" + i);
                    return i * 2;
                }, context);
                Console.WriteLine("计算结果：" + result);
                Thread.Sleep(500);
            }
        }
    }
}