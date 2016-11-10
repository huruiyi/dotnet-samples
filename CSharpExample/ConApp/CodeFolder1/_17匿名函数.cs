using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConApp.CodeFolder1
{
    public class MyThread
    {
        public ParameterizedThreadStart CallBackFunc { get; set; }

        public MyThread(ParameterizedThreadStart start)
        {
            CallBackFunc = start;
        }

        public void Start(object obj)
        {
            CallBackFunc(obj);
        }
    }

    public class _17匿名函数
    {
        internal delegate int MyAddFunDel(int a, int b);

        private static int AddStatic(int a, int b)
        {
            Console.WriteLine("AddStatic 执行了...、" + Thread.CurrentThread.ManagedThreadId + "\r\n");

            Thread.Sleep(3000);

            return a + b;
        }

        public static void Main17(string[] args)
        {
            #region 匿名函数

            MyAddFunDel delLambda0 = delegate (int i, int i1) { return i + i1; };

            Console.WriteLine(delLambda0(3, 2));

            MyAddFunDel delLambda1 = (i, i1) => { return i + i1; };
            Console.WriteLine(delLambda1(3, 2));

            MyAddFunDel delLambda2 = (i, i1) => i + i1;
            Console.WriteLine(delLambda2(3, 2));

            #endregion 匿名函数

            #region 泛型委托

            //一共有16个  最后一个是 约束返回值
            Func<int, bool> del = a => a > 2;

            List<int> myIntLst = new List<int>() { 1, 2, 3, 4, 5, 6, 87 };

            //把一个委托传递到一个方法里面去，然后在方法里面调用。判断集合满足条件的给返回
            var result = myIntLst.Where(del);
            var result2 = myIntLst.Where(a => a > 2);

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }

            #endregion 泛型委托

            #region 异步委托

            Console.WriteLine(" 主线程是：{0}", Thread.CurrentThread.ManagedThreadId);

            MyAddFunDel myDel = new MyAddFunDel(AddStatic);

            //myDel(1,3)
            IAsyncResult delResult = myDel.BeginInvoke(3, 4, null, 2);

            while (!delResult.IsCompleted)
            {
                //主线程干其他事
            }
            int addResult = myDel.EndInvoke(delResult);
            Console.WriteLine("主线程获得结果是：{0}", addResult);

            #endregion 异步委托

            #region 应用程序域

            AppDomain.Unload(AppDomain.CurrentDomain);

            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                Console.WriteLine("这是主应");
            }

            //我们自己写一个AppDomain
            // 设置应用程序域
            AppDomainSetup appDomainSetup = new AppDomainSetup();

            //设置程序集不共享
            appDomainSetup.LoaderOptimization = LoaderOptimization.SingleDomain;

            // 主应用程序域创建 程序域
            AppDomain appDomain = AppDomain.CreateDomain("MultThread", null, appDomainSetup);
            // 程序域  执行exe
            // 每个应用程序域  只能执行一个exe，但是可以加载多个 dll
            appDomain.ExecuteAssembly("MultThread.exe");

            #endregion 应用程序域

            Console.ReadKey();
        }
    }
}