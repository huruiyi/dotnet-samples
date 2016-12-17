using System;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThread
{
    public delegate int AddDel(int a, int b);

    internal class Work
    {
        public static void DoWork()
        {
            Console.WriteLine("Static thread procedure.");
        }

        public int Data;

        public void DoMoreWork()
        {
            Console.WriteLine("Instance thread procedure. Data={0}", Data);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        public static void DoWork(object objPer)
        {
            Person per = objPer as Person;
            if (per != null)
            {
                Console.WriteLine($"Helo I am {per.Name},{per.Sex},{per.Age} years old");
            }
        }

        private static void Demo1()
        {
            Thread t1 = new Thread(Work.DoWork);
            t1.Start();

            ThreadStart ts = new ThreadStart(Work.DoWork);
            Thread t2 = new Thread(ts);
            t2.Start();

            Work w = new Work();
            w.Data = 30;
            ThreadStart tss = new ThreadStart(w.DoMoreWork);
            Thread t3 = new Thread(tss);
            t3.Start();

            Person per = new Person { Name = "小明", Age = 19, Sex = "nan" };

            ParameterizedThreadStart pt1 = new ParameterizedThreadStart(DoWork);
            pt1(per);

            ParameterizedThreadStart pt2 = new ParameterizedThreadStart(DoWork);
            pt2(per);

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Thread t4 = new Thread(pt2);
            t4.Start(per);
            Console.Read();
        }

        private static void Demo2()
        {
            Person person = new Person { Name = "Ruin", Sex = "nam" };
            Thread t2 = new Thread(p => SayHi(person));
            t2.Start();

            Thread t1 = new Thread(() => Say("sas"));
            t1.Start();
            Thread t3 = new Thread(delegate () { Console.WriteLine("dsadasd"); Say("sas"); });
            t3.Start();

            Thread t7 = new Thread(delegate () { SayHi(person); });
            t7.Start();

            var t4 = new Thread(delegate (object objPerson)
            {
                var per = objPerson as Person;
                if (per != null)
                    Console.WriteLine("姓名：" + per.Name);
            });
            t4.Start(person);

            var t5 = new Thread(Start);
            t5.Start();
            //new Thread(new ParameterizedThreadStart(PrintMessage));
            var t6 = new Thread(PrintMessage);
            t6.Start("打印信息如下......");
        }

        private static void Demo3()
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
            Parallel.For(1, 1000000, i =>
            {
                lock (lck)
                {
                    sum[0] += i;
                }
                Console.WriteLine("当前执行到 ：" + i + "@" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            });

            Console.WriteLine(sum[0]);

            sum[0] = 0;

            for (int i = 1; i < 1000000; i++)
            {
                sum[0] += i;
            }

            Console.WriteLine(sum[0] + "---");

            #endregion 并行计算

            Console.WriteLine("主线程执行完毕。。。");
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

        private static void Start()
        {
            Console.WriteLine("Start.......");
        }

        private static void Say(string s)
        {
            Console.WriteLine("Say........" + s);
        }

        private static void SayHi(Person p)
        {
            Console.WriteLine(p.Name + "" + p.Sex);
        }

        private static void PrintMessage(object msg)
        {
            var sMsg = (string)msg;
            Console.WriteLine(sMsg);
            Thread.Sleep(500);
        }
    }
}