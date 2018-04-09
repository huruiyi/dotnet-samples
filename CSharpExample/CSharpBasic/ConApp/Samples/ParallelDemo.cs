using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConApp
{
    public class ParallelDemo
    {
        /// <summary>
        /// Thread Execution Order
        /// </summary>
        public static void Demo1()
        {
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("My i value is " + i);
            });

            Console.WriteLine("Press any key to continue...");
        }

        public static void Demo2()
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

        private static void Demo3()
        {
            List<int> intList = new List<int>();
            var result = Parallel.ForEach(Enumerable.Range(1, 10000), (val) =>
            {
                intList.Add(val);
            });
            if (result.IsCompleted)
            {
                Console.WriteLine("intList.Count():" + intList.Count);
            }
        }

        private static void Demo4()
        {
            ConcurrentBag<int> intList = new ConcurrentBag<int>();
            //ConcurrentList<int> intList = new ConcurrentList<int>();
            var result = Parallel.ForEach(Enumerable.Range(1, 10000), (val) =>
            {
                intList.Add(val);
            });
            if (result.IsCompleted)
            {
                Console.WriteLine("intList.Count():" + intList.Count);
            }
        }
    }
}
