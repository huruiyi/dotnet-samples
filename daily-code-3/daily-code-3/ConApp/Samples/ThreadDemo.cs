using System;
using System.Threading;

namespace ConApp.Samples
{
    public class TicketSeller
    {
        public static int TicketCount = 100;
        public static object locker = new object();

        public TicketSeller(string name)
        {
            System.Threading.Thread th = new System.Threading.Thread(Seller)
            {
                IsBackground = true
            };
            bool ipt = th.IsThreadPoolThread;
            th.Name = name;
            th.Start();
        }

        private void Seller()
        {
            while (TicketCount > 0)
            {
                lock (locker)
                {
                    TicketCount--;
                    Console.WriteLine("{1},剩余:{0}", TicketCount, System.Threading.Thread.CurrentThread.Name);
                }
            }
        }
    }

    public class StatusChecker
    {
        private int invokeCount;
        private int maxCount;

        public StatusChecker(int count)
        {
            invokeCount = 0;
            maxCount = count;
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.",
                DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount).ToString());

            if (invokeCount == maxCount)
            {
                // Reset the counter and signal the waiting thread.
                invokeCount = 0;
                autoEvent.Set();
            }
        }
    }

    public class User
    {
        public enum UserClass
        {
            ClassAdmin,
            ClassUser
        }

        public void AdminMethod()
        {
            Console.WriteLine("Admin Method has procceed!");
        }

        public void UserMethod()
        {
            Console.WriteLine("User Method has procceed!");
        }

        public void ExecuteFor(UserClass uc)
        {
            //由于是静态的方法不需要实例化也可以进行访问
            ThreadStart tsAd = AdminMethod;
            ThreadStart tsUs = UserMethod;

            var ts = uc == UserClass.ClassAdmin ? tsAd : tsUs;

            System.Threading.Thread t = new System.Threading.Thread(ts);
            t.Start();
        }
    }

    public class Animal
    {
        //成员变量
        public string Name { get; set; }

        public string Id { get; set; }

        //构造器
        public Animal()
        {
            Name = "Kitty";
            Id = "0516";
        }

        public Animal(string a_id, string a_name)
        {
            Name = a_name;
            Id = a_id;
        }

        //成员函数
        public void sports()
        {
            Console.WriteLine("There is a girl called " + Name + " doing sports!");
        }

        public void Thread_person()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("Animal id is " + i);
            }

            //Console.WriteLine("There is a thread calling that called :" + AppDomain.GetCurrentThreadId());            
            Console.WriteLine("There is a thread calling that called :" + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }

    public class ThreadDemo
    {
        #region Demo1

        //存放要计算的数值的字段
        private static double _number1 = -1;

        private static double _number2 = -1;

        //启动第一个任务：计算x的8次方
        private static void TaskProc1(object o)
        {
            _number1 = Math.Pow(Convert.ToDouble(o), 8);
        }

        //启动第二个任务：计算x的8次方根
        private static void TaskProc2(object o)
        {
            _number2 = Math.Pow(Convert.ToDouble(o), 1.0 / 8.0);
        }

        private static void Demo1()
        {
            //获取线程池的最大线程数和维护的最小空闲线程数

            ThreadPool.GetMaxThreads(out var maxThreadNum, out _);
            ThreadPool.GetMinThreads(out var minThreadNum, out _);
            Console.WriteLine("最大线程数：{0}", maxThreadNum);
            Console.WriteLine("最小线程数：{0}", minThreadNum);

            //函数变量值
            int x = 15600;
            //启动第一个任务：计算x的8次方
            Console.WriteLine("启动第一个任务：计算{0}的8次方。", x);
            ThreadPool.QueueUserWorkItem(TaskProc1, x);

            //启动第二个任务：计算x的8次方根
            Console.WriteLine("启动第二个任务：计算{0}的8次方根。", x);
            ThreadPool.QueueUserWorkItem(TaskProc2, x);

            //等待，直到两个数值都完成计算
            while (_number1 == -1 || _number2 == -1) ;
            //打印计算结果
            Console.WriteLine("y({0}) = {1}", x, _number1 + _number2);
        }

        #endregion Demo1

        private static void Demo2()
        {
            new TicketSeller("1号台");
            new TicketSeller("2号台");
        }

        private static object objlock = new object();

        private static void Thread_Demo0()
        {
            //Console.WriteLine("From the thread ID is:" + AppDomain.GetCurrentThreadId());
            Console.WriteLine("This code caculate the value " + 123 + "from thread ID:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        public static void WorkFunction()
        {
            string ThreadState;
            for (int i = 1; i < 100000; i++)
            {
                if (i % 5000 == 0)
                {
                    ThreadState = System.Threading.Thread.CurrentThread.ThreadState.ToString();
                    Console.WriteLine("Worker :" + ThreadState);
                }
            }
            Console.WriteLine("Worker function Completed!");
        }

        private static void Thread_Demo1()
        {
            Animal ps = new Animal();
            ThreadStart p = ps.sports;
            ThreadStart p2 = ps.Thread_person;
            System.Threading.Thread p1 = new System.Threading.Thread(p);
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("Primary id is " + i.ToString());
            }
            System.Threading.Thread p3 = new System.Threading.Thread(p2);

            p1.Start();
            p3.Start();
        }

        private static void Thread_Demo2()
        {
            System.Threading.Thread thread1 = new System.Threading.Thread(WorkFunction);

            thread1.Start();

            while (thread1.IsAlive)
            {
                System.Threading.Thread thread2 = new System.Threading.Thread(WorkFunction);
                thread2.Start();
                if (thread2.IsAlive)
                {
                    Console.WriteLine("Please wait a min...");
                    System.Threading.Thread.Sleep(5000);
                }
                Console.WriteLine("still wating...");
                System.Threading.Thread.Sleep(200);
            }

            var st = thread1.ThreadState.ToString();
            Console.WriteLine("He's finally done!Thread static is :" + st);

            User c = new User();
            c.ExecuteFor(User.UserClass.ClassAdmin);
        }

        private static void Thread_Demo3()
        {
            System.Threading.Thread t1 = new System.Threading.Thread(delegate ()
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Hello" + i);
                }
            });
            t1.DisableComObjectEagerCleanup();
        }

        public static void DoTask(Object stateInfo)
        {
            lock (objlock)
            {
            }
        }

        public static void TdTimer1()
        {
            // Create an AutoResetEvent to signal the timeout threshold in the
            // timer callback has been reached.
            var autoEvent = new AutoResetEvent(false);

            var statusChecker = new StatusChecker(10);

            // Create a timer that invokes CheckStatus after one second,
            // and every 1/4 second thereafter.
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n", DateTime.Now);
            var stateTimer = new Timer(statusChecker.CheckStatus, autoEvent, 1000, 250);

            // When autoEvent signals, change the period to every half second.
            autoEvent.WaitOne();
            stateTimer.Change(0, 500);
            Console.WriteLine("\nChanging period to .5 seconds.\n");

            // When autoEvent signals the second time, dispose of the timer.
            autoEvent.WaitOne();
            stateTimer.Dispose();
        }

        public static void ThTimer()
        {
            using (Timer fTimer = new Timer(new TimerCallback(DoTask), new AutoResetEvent(false), 0, 1000))
            {
            }
        }

        public static void AsyncFuncDemo()
        {
            Func<bool> ascyRun = ProcessCount;
            IAsyncResult reslu = ascyRun.BeginInvoke(MyAsyncCallback, ascyRun);

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(200);

                Console.WriteLine("End。。。。。。。。");
            }
        }

        public static void MyAsyncCallback(IAsyncResult ar)
        {
            Func<bool> pc = (Func<bool>)ar.AsyncState;
            var endInvoke = pc.EndInvoke(ar);
            Console.WriteLine(endInvoke ? "处理完成。。" : "处理失败。。");
        }

        public static bool ProcessCount()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + "\t");
                System.Threading.Thread.Sleep(100);
            }
            return true;
        }
    }
}
