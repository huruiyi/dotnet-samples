using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConApp.Samples
{
    public class TaskDemo
    {
        private static volatile int _number;

        public static void DoAction()
        {
            object obj = new object();
            Task task1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    lock (obj)
                    {
                        _number++;
                    }
                }
            });

            Task task2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    lock (obj)
                    {
                        _number++;
                    }
                }
            });

            Task.WaitAll(task1, task2);
            Console.WriteLine(_number);
        }

        public static void CancellationTokenDemo()
        {
            // Define the cancellation token.
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            Object lockObj = new Object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 5);
                        }

                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }

                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                    (results) =>
                    {
                        Console.WriteLine("Calculating overall mean...");
                        long sum = 0;
                        int n = 0;
                        foreach (var t in results)
                        {
                            foreach (var r in t.Result)
                            {
                                sum += r;
                                n++;
                            }
                        }

                        return sum / (double)n;
                    }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Unable to compute mean: {0}", ((TaskCanceledException)e).Message);
                    else
                        Console.WriteLine("Exception: " + e.GetType().Name);
                }
            }
            finally
            {
                source.Dispose();
            }
        }

        //声明CancellationTokenSource对象
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        private static void MyTask()
        {
            //判断是否取消任务
            while (!cancelTokenSource.IsCancellationRequested)
            {
                Console.WriteLine(DateTime.Now);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private static void SimpleCancellationTokenDemo()
        {
            Task.Factory.StartNew(MyTask, cancelTokenSource.Token);

            Console.WriteLine("请按回车键(Enter)停止");
            Console.ReadLine();

            cancelTokenSource.Cancel();

            Console.WriteLine("已停止");
        }

        static void Task_Demo0()
        {
            string[] filenames = { "chapter1.txt", "chapter2.txt", "chapter3.txt", "chapter4.txt", "chapter5.txt" };
            string pattern = @"\b\w+\b";
            var tasks = new List<Task>();
            int totalWords = 0;

            // Determine the number of words in each file.
            foreach (var filename in filenames)
                tasks.Add(Task.Factory.StartNew(fn =>
                {
                    if (!File.Exists(fn.ToString()))
                        throw new FileNotFoundException("{0} does not exist.", filename);

                    StreamReader sr = new StreamReader(fn.ToString());
                    String content = sr.ReadToEnd();
                    sr.Close();
                    int words = Regex.Matches(content, pattern).Count;
                    Interlocked.Add(ref totalWords, words);
                    Console.WriteLine("{0,-25} {1,6:N0} words", fn, words);
                }, filename));

            var finalTask = Task.Factory.ContinueWhenAll(tasks.ToArray(), wordCountTasks =>
            {
                int nSuccessfulTasks = 0;
                int nFailed = 0;
                int nFileNotFound = 0;
                foreach (var t in wordCountTasks)
                {
                    if (t.Status == TaskStatus.RanToCompletion)
                        nSuccessfulTasks++;

                    if (t.Status == TaskStatus.Faulted)
                    {
                        nFailed++;
                        t.Exception.Handle((e) =>
                        {
                            if (e is FileNotFoundException)
                                nFileNotFound++;
                            return true;
                        });
                    }
                }

                Console.WriteLine("\n{0,-25} {1,6} total words\n", String.Format("{0} files", nSuccessfulTasks), totalWords);
                if (nFailed > 0)
                {
                    Console.WriteLine("{0} tasks failed for the following reasons:", nFailed);
                    Console.WriteLine("   File not found:    {0}", nFileNotFound);
                    if (nFailed != nFileNotFound)
                        Console.WriteLine("   Other:          {0}", nFailed - nFileNotFound);
                }
            });
            finalTask.Wait();
        }
    }
}
