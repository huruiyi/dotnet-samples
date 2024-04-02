using System;
using System.Threading.Tasks;

namespace ConApp.Samples.Thread
{
    /// <summary>
    /// This test app has a race condition between exiting the lock and printing the Count again.
    /// You'll see duplicated and missing iteration values in the output.
    /// </summary>
    internal class RaceConditionConsoleApp
    {
        private static object _syncRoot = new object();

        public static int Count { get; set; }

        private static void Run(string[] args)
        {
            Parallel.For(0, 100, new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            }, i =>
            {
                ThreadingMethod();
            });

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void ThreadingMethod()
        {
            int localCount = 0;

            lock (_syncRoot)
            {
                // Critical section（临界区）
                localCount = ++Count;
                Console.WriteLine("Count is now " + Count);
            }

            // Use a slight delay to help show threading behavior
            System.Threading.Thread.Sleep(10);

            // Do more work here
            Console.WriteLine("Completing ThreadingMethod " + Count + " execution.");
        }
    }
}