using System;
using System.Threading.Tasks;

namespace ConApp.Samples.Thread
{
    /// <summary>
    /// This program shows how locking more than what's needed reduces multithreading efficiency.
    /// This output will always be in sequential order because it's effectively single threaded.
    /// </summary>
    internal class IneffectiveLockingConsoleApp
    {
        private static object _syncRoot = new object();

        public static int Count { get; set; }

        private static void Run()
        {
            int iterations = 100;

            Parallel.For(0, iterations, new ParallelOptions
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
            // NOTE:  No work is being done outside the lock.
            lock (_syncRoot)
            {
                // Critical section（临界区）
                ++Count;
                Console.WriteLine("Count is now " + Count);
                Console.WriteLine("Completing ThreadingMethod " + Count + " execution.");
            }
        }
    }
}