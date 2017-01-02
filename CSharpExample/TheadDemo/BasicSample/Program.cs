using System;
using System.Collections.Generic;
using System.Reflection;

namespace BasicSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Type[] types = asm.GetTypes();

            List<Type> typeList = new List<Type>();
            IDictionary<int, Type> typeMap = new Dictionary<int, Type>();
            int counter = 1;

            foreach (Type t in types)
            {
                if (new List<Type>(t.GetInterfaces()).Contains(typeof(IExample)))
                {
                    typeList.Add(t);
                    typeMap.Add(counter++, t);
                }
            }

            foreach (KeyValuePair<int, Type> keyValuePair in typeMap)
            {
                Console.WriteLine("{0}:{1}", keyValuePair.Key.ToString().PadLeft(2, '0'), keyValuePair.Value.Name);
            }
            Console.WriteLine("请输入编号执行");
            string strNum = Console.ReadLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            IExample demo = Activator.CreateInstance(typeMap[Convert.ToInt16(strNum)]) as IExample;
            demo.Invoke();

            //Task<string> task = new Task<string>(() =>
            //{
            //    Console.WriteLine("当前线程是:" + Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(2000);
            //    return "shit";
            //});

            //task.Start();//通过线程池获取一个线程然后执行  回调方法
            //task.Wait();
            //task.Wait(5000);
            //Console.WriteLine(task.Result);

            Console.ReadKey();
        }
    }
}