using System;
using System.Threading;
using System.Threading.Tasks;

namespace 代码集合
{
    public class MyConnection
    {
        public string Name { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            QueueUserWorkItemDemo();

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

        private static void QueueUserWorkItemDemo()
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

        private static void ProducerConsumer()
        {
            //定义一个对象池
            MyConnection[] connArrary = new MyConnection[100];

            int index = 0;

            Program p = new Program();

            //生产者
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        //等着拿到的P变量的锁
                        lock (p)//建议使用lock///不能锁 值类型
                        {
                            //Monitor.Enter(p);
                            MyConnection conn = new MyConnection();
                            if (index >= 100 || index < 0)
                            {
                                continue;//生产者继续生产
                            }
                            connArrary[index] = conn;
                            index++;
                            Console.WriteLine("生产一个产品 @" + Thread.CurrentThread.ManagedThreadId);
                        }
                        Thread.Sleep(300);
                    }
                })
                { IsBackground = true };

                thread.Start();
            }

            //////消费者

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        lock (p)
                        {
                            if (index <= 0)
                            {
                                continue;
                            }
                            connArrary[index - 1] = null;
                            index--;
                            Console.WriteLine("消费一个产品 @" + Thread.CurrentThread.ManagedThreadId);
                            Thread.Sleep(300);
                        }
                    }
                })
                { IsBackground = true };

                thread.Start();
            }
        }
    }
}