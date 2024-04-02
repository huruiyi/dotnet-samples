using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConApp.Samples.Thread
{
    /// <summary>
    /// This shows some really basic implementations of running some Parallel loops.
    /// It's using a SyncRoot pattern inside the Action because the shared resource, NumberList,
    /// is not thread-safe.  Also demonstrates basic exception handling.
    /// </summary>
    internal class SampleParallelConsoleApp
    {
        private static void Run()
        {
            NumberList = new List<int>();

            var sourcesWithNull = new List<string>() { "0", "1", "2", "3", null, "5", "6", "7", "8", "9" };

            ThreadedAddNumbers(sourcesWithNull);

            var sourcesWithJunk = new List<string>() { "10", "11", "boo!", "13", "14", "15", "16", "17", "18", "19" };

            ThreadedAddNumbers(sourcesWithJunk);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static object _numberListSyncRoot = new object();

        public static List<int> NumberList { get; set; }

        public static void ThreadedAddNumbers(IEnumerable<string> numbers)
        {
            try
            {
                Parallel.ForEach(numbers, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (s, loopState) =>
                {
                    try
                    {
                        // Conversion/parsing is often a relatively costly task.
                        // This work is outside of the critical section.
                        var number = Int32.Parse(s);

                        // This call contains the critical section
                        AddNumber(number);

                        // Add a delay to help exhibit behavior
                        // NOTE:  Exceptions are expensive to catch, so if you don't do this the exceptions are
                        // almost always thrown after everything finished.
                        //System.Threading.Thread.Sleep(10);

                        Console.WriteLine("Added " + number);
                    }
                    catch (ArgumentNullException)
                    {
                        // Can't add nulls, but we know about this and it's okay.
                        Console.WriteLine("Got a null, ignoring.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("WTF!");
                        loopState.Stop();

                        throw ex;
                    }
                });
            }
            catch (AggregateException)
            {
                Console.WriteLine("Dammit Jim!  I'm a doctor not an exception handler!");
            }
        }

        public static void AddNumber(int number)
        {
            lock (_numberListSyncRoot)
            {
                NumberList.Add(number);
            }
        }
    }
}