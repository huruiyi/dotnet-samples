using ConApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ConApp
{
    public class TaskDemo
    {
        public static void TaskCancellationTokenDemo1()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            token.Register(delegate { Console.WriteLine("cancel........."); });
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
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine(@"Cancelling at task {0}", iteration);
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
                Console.WriteLine(@"The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine(@"Unable to compute mean: {0}", ((TaskCanceledException)e).Message);
                    }
                    else
                    {
                        Console.WriteLine("Exception: " + e.GetType().Name);
                    }
                }
            }
            finally
            {
                source.Dispose();
            }
        }

        public static void TaskCancellationTokenDemo2()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            object lockObj = new object();

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
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine(@"Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask =
                factory.ContinueWhenAll(tasks.ToArray(), (results) =>
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
                Console.WriteLine(@"The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine(@"Unable to compute mean: {0}", e.Message);
                    }
                    else
                    {
                        Console.WriteLine("Exception: " + e.GetType().Name);
                    }
                }
            }
            finally
            {
                source.Dispose();
            }
        }

        public static void TaskDemo2()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task tack = Task.Factory.StartNew(delegate ()
            {
                GetPseronList1(pers1);
                GetPseronList2(pers2);
                GetPseronList3(pers3);
                GetPseronList4(pers4);
                GetPseronList5(pers5);
            });
            tack.ContinueWith(delegate (Task task)
            {
                Console.WriteLine("执行完成");
            });
        }

        public static void TaskWhenAll3()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task t1 = Task.Run(() => { GetPseronList1(pers1); });
            Task t2 = Task.Run(() => { GetPseronList2(pers2); });
            Task t3 = Task.Run(() => { GetPseronList3(pers3); });
            Task t4 = Task.Run(() => { GetPseronList4(pers4); });
            Task t5 = Task.Run(() => { GetPseronList5(pers5); });

            //Task tb = Task.WhenAll(t1, t2, t3, t4, t5);
            //tb.ContinueWith((Task tt) => { Console.WriteLine("执行完成"); });
        }

        public static void TaskContinueWithDemo()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task task = Task.Factory.StartNew(() =>
            {
                Parallel.Invoke(
                    delegate { GetPseronList1(pers1); },
                    delegate { GetPseronList2(pers2); },
                    delegate { GetPseronList3(pers3); },
                    delegate { GetPseronList4(pers4); },
                    delegate { GetPseronList5(pers5); });
            });
            Task.WaitAll();
            task.ContinueWith(delegate (Task tt) { Console.WriteLine(@"执行完成,{0}", tt.Status); }
            );
        }

        public static void GetPseronList1(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl1Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine(@"p1Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList2(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl1Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine(@"p2Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList3(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl2Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine(@"p3Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList4(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl3Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine(@"p4Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList5(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl4Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine(@"p5Listp{0}创建成功", i);
            }
        }

        public static void SpinWaitDemo()
        {
            // Demonstrates:
            //      SpinWait construction
            //      SpinWait.SpinOnce()
            //      SpinWait.NextSpinWillYield
            //      SpinWait.Count
            bool someBoolean = false;
            int numYields = 0;

            // First task: SpinWait until someBoolean is set to true
            Task t1 = Task.Factory.StartNew(() =>
            {
                SpinWait sw = new SpinWait();
                while (!someBoolean)
                {
                    // The NextSpinWillYield property returns true if
                    // calling sw.SpinOnce() will result in yielding the
                    // processor instead of simply spinning.
                    if (sw.NextSpinWillYield) numYields++;
                    sw.SpinOnce();
                }

                // As of .NET Framework 4: After some initial spinning, SpinWait.SpinOnce() will yield every time.
                Console.WriteLine(@"SpinWait called {0} times, yielded {1} times", sw.Count, numYields);
            });

            // Second task: Wait 100ms, then set someBoolean to true
            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                someBoolean = true;
            });

            // Wait for tasks to complete
            Task.WaitAll(t1, t2);
        }

        public static void TaskActionDemo()
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);
            };

            // Construct an unstarted task
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");

            // Block the main thread to demonstate that t2 is executing
            t2.Wait();

            t1.Start();

            Console.WriteLine(@"t1 has been launched. (Main Thread={0})", Thread.CurrentThread.ManagedThreadId);

            // Wait for the task to finish.
            // You may optionally provide a timeout interval or a cancellation token
            // to mitigate situations when the task takes too long to finish.
            t1.Wait();

            // Construct an unstarted task
            Task t3 = new Task(action, "gamma");

            // Run it synchronously
            t3.RunSynchronously();

            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t3.Wait();
        }

        // Demonstrates:
        //      ManualResetEventSlim construction
        //      ManualResetEventSlim.Wait()
        //      ManualResetEventSlim.Set()
        //      ManualResetEventSlim.Reset()
        //      ManualResetEventSlim.IsSet
        public static void MRES_SetWaitReset()
        {
            ManualResetEventSlim mres1 = new ManualResetEventSlim(false); // initialize as unsignaled
            ManualResetEventSlim mres2 = new ManualResetEventSlim(false); // initialize as unsignaled
            ManualResetEventSlim mres3 = new ManualResetEventSlim(true);  // initialize as signaled

            // Start an asynchronous Task that manipulates mres3 and mres2
            var observer = Task.Factory.StartNew(() =>
            {
                mres1.Wait();
                Console.WriteLine("observer sees signaled mres1!");
                Console.WriteLine("observer resetting mres3...");
                mres3.Reset(); // should switch to unsignaled
                Console.WriteLine("observer signalling mres2");
                mres2.Set();
            });

            Console.WriteLine(@"main thread: mres3.IsSet = {0} (should be true)", mres3.IsSet);
            Console.WriteLine("main thread signalling mres1");
            mres1.Set(); // This will "kick off" the observer Task
            mres2.Wait(); // This won't return until observer Task has finished resetting mres3
            Console.WriteLine("main thread sees signaled mres2!");
            Console.WriteLine(@"main thread: mres3.IsSet = {0} (should be false)", mres3.IsSet);

            // It's good form to Dispose() a ManualResetEventSlim when you're done with it
            observer.Wait(); // make sure that this has fully completed
            mres1.Dispose();
            mres2.Dispose();
            mres3.Dispose();
        }

        // Demonstrates:
        //      ManualResetEventSlim construction w/ SpinCount
        //      ManualResetEventSlim.WaitHandle
        public static void MRES_SpinCountWaitHandle()
        {
            // Construct a ManualResetEventSlim with a SpinCount of 1000
            // Higher spincount => longer time the MRES will spin-wait before taking lock
            ManualResetEventSlim mres1 = new ManualResetEventSlim(false, 1000);
            ManualResetEventSlim mres2 = new ManualResetEventSlim(false, 1000);

            Task bgTask = Task.Factory.StartNew(() =>
            {
                // Just wait a little
                Thread.Sleep(100);

                // Now signal both MRESes
                Console.WriteLine("Task signalling both MRESes");
                mres1.Set();
                mres2.Set();
            });

            // A common use of MRES.WaitHandle is to use MRES as a participant in
            // WaitHandle.WaitAll/WaitAny.  Note that accessing MRES.WaitHandle will
            // result in the unconditional inflation of the underlying ManualResetEvent.
            WaitHandle.WaitAll(new WaitHandle[] { mres1.WaitHandle, mres2.WaitHandle });
            Console.WriteLine("WaitHandle.WaitAll(mres1.WaitHandle, mres2.WaitHandle) completed.");

            // Clean up
            bgTask.Wait();
            mres1.Dispose();
            mres2.Dispose();
        }

        public static void ParallelTask()
        {
            Console.WriteLine("Start......");
            Task.Factory.StartNew(delegate
            {
                M1();
                M2();
                M3();
            });
            Parallel.Invoke(M1, M2, M3);
            Console.WriteLine("End......");
        }

        public static void M1()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);

                Console.WriteLine("M1............");
            }
        }

        public static void M2()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);

                Console.WriteLine("M2............");
            }
        }

        public static void M3()
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("M3............");
            }
        }

        #region 查看端口是否被占用

        public static void PortInDemo()
        {
            for (int i = 1; i <= 8; i++)
            {
                ParameterizedThreadStart pts = x =>
                {
                    for (int j = 1000 * ((int)x - 1) + 1; j <= 1000 * (int)x; j++)
                    {
                        PortCon(j);
                    }
                };

                Thread t = new Thread(pts);
                t.Start(i);
            }
        }

        public static void PortISOpen0()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(ip, 80);
            try
            {
                TcpClient tcp = new TcpClient();
                tcp.Connect(point);
                Console.WriteLine("打开的端口");
            }
            catch (Exception ex)
            {
                Console.WriteLine("已开启的端口:" + ex.Message);
            }
        }

        public static void PortISOpen1()
        {
            HttpListener httpListner = new HttpListener();
            httpListner.Prefixes.Add("http://*:8080/");
            httpListner.Start();
            Console.WriteLine("Port: 8080 status: " + (PortInUse(8080) ? "in use" : "not in use"));
        }

        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }

        public static void PortCon(object port)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(ip, (int)port);
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(point);
                Console.WriteLine(@"{0}成功!", point);
            }
            catch (SocketException e)
            {
                if (e.ErrorCode != 10061)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(@"{0}失败", port);
            }
        }

        #endregion 查看端口是否被占用

        public static void SumPageSizes()
        {
            // Make a list of web addresses.
            List<string> urlList = SetUpURLList();

            var total = 0;
            foreach (var url in urlList)
            {
                // GetURLContents returns the contents of url as a byte array.
                byte[] urlContents = GetURLContents(url);

                DisplayResults(url, urlContents);

                // Update the total.
                total += urlContents.Length;
            }

            // Display the total count for all of the web addresses.
            Console.WriteLine($"\r\n\r\nTotal bytes returned:  {total}\r\n");
        }

        public static async void SumPageSizesAsync()
        {
            // Make a list of web addresses.
            List<string> urlList = SetUpURLList();

            var total = 0;
            foreach (var url in urlList)
            {
                // GetURLContents returns the contents of url as a byte array.
                byte[] urlContents = await GetURLContentsAsync(url);

                DisplayResults(url, urlContents);

                // Update the total.
                total += urlContents.Length;
            }

            // Display the total count for all of the web addresses.
            Console.WriteLine($"\r\n\r\nTotal bytes returned:  {total}\r\n");
        }

        private static void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format
            // is designed to be used with a monospaced font, such as
            // Lucida Console or Global Monospace.
            var bytes = content.Length;
            // Strip off the "https://".
            var displayURL = url.Replace("https://", "");
            Console.WriteLine($"\n{displayURL,-58} {bytes,8}");
        }

        private static List<string> SetUpURLList()
        {
            var urls = new List<string>
            {
                "https://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "https://msdn.microsoft.com",
                "https://msdn.microsoft.com/library/hh290136.aspx",
                "https://msdn.microsoft.com/library/ee256749.aspx",
                "https://msdn.microsoft.com/library/hh290138.aspx",
                "https://msdn.microsoft.com/library/hh290140.aspx",
                "https://msdn.microsoft.com/library/dd470362.aspx",
                "https://msdn.microsoft.com/library/aa578028.aspx",
                "https://msdn.microsoft.com/library/ms404677.aspx",
                "https://msdn.microsoft.com/library/ff730837.aspx"
            };
            return urls;
        }

        private static byte[] GetURLContents(string url)
        {
            // The downloaded resource ends up in the variable named content.
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for
            // the response.
            // Note: you can't use HttpWebRequest.GetResponse in a Windows Store app.
            using (WebResponse response = webReq.GetResponse())
            {
                // Get the data stream that is associated with the specified URL.
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Read the bytes in responseStream and copy them to content.
                    responseStream.CopyTo(content);
                }
            }

            // Return the result as a byte array.
            return content.ToArray();
        }

        private static async Task<byte[]> GetURLContentsAsync(string url)
        {
            // The downloaded resource ends up in the variable named content.
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for
            // the response.
            using (WebResponse response = await webReq.GetResponseAsync())

            // The previous statement abbreviates the following two statements.

            //Task<WebResponse> responseTask = webReq.GetResponseAsync();
            //using (WebResponse response = await responseTask)
            {
                // Get the data stream that is associated with the specified url.
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Read the bytes in responseStream and copy them to content.
                    await responseStream.CopyToAsync(content);

                    // The previous statement abbreviates the following two statements.

                    // CopyToAsync returns a Task, not a Task<T>.
                    //Task copyTask = responseStream.CopyToAsync(content);

                    // When copyTask is completed, content contains a copy of
                    // responseStream.
                    //await copyTask;
                }
            }
            // Return the result as a byte array.
            return content.ToArray();
        }
    }
}