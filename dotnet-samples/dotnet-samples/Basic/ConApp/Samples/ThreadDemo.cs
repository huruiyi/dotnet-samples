﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ConApp
{
    public class ThreadDemo
    {
        #region 实现1

        private static readonly object MRes1 = new object();
        private static readonly object MRes2 = new object();
        private static int _mCount = 0;

        private static void Thread1()
        {
            while (true)
            {
                Monitor.Enter(MRes2);  // 先锁 m_res2
                Monitor.Enter(MRes1);  // 再锁 m_res1

                _mCount++;

                Monitor.Exit(MRes1);  // 释放锁不存在先后关系
                Monitor.Exit(MRes2);
            }
        }

        private static void Thread2()
        {
            while (true)
            {
                Monitor.Enter(MRes1);  // 先锁 m_res1
                Monitor.Enter(MRes2);

                _mCount++;

                Monitor.Exit(MRes1);
                Monitor.Exit(MRes2);
            }
        }

        public static void DeadDemo1()
        {
            Thread t1 = new Thread(Thread1);
            Thread t2 = new Thread(Thread2);

            t1.Start();
            t2.Start();

            while (true)
            {
                int preCount = _mCount;
                Thread.Sleep(0);  // 放弃当前线程的CPU时间片，Windows可能调度其他线程
                if (preCount == _mCount)  // 数据没有变化，表明线程没有执行
                {
                    Console.WriteLine(@"dead lock! count: {0}---{1}", _mCount, DateTime.Now.Ticks);
                }
            }
        }

        #endregion 实现1

        #region 实现2

        private static readonly Object ObjA = new Object();
        private static readonly Object ObjB = new Object();

        private static void LockA()
        {
            if (Monitor.TryEnter(ObjA, 1000))
            {
                Thread.Sleep(1000);
                if (Monitor.TryEnter(ObjB, 2000))
                {
                    Monitor.Exit(ObjB);
                }
                else
                {
                    Console.WriteLine("LockB timeout");
                }
                Monitor.Exit(ObjA);
            }
            Console.WriteLine("LockA");
        }

        private static void LockB()
        {
            if (Monitor.TryEnter(ObjB, 2000))
            {
                Thread.Sleep(2000);
                if (Monitor.TryEnter(ObjA, 1000))
                {
                    Monitor.Exit(ObjA);
                }
                else
                {
                    Console.WriteLine("LockA timeout");
                }
                Monitor.Exit(ObjB);
            }
            Console.WriteLine("LockB");
        }

        public static void DeadDemo2()
        {
            Thread threadA = new Thread(LockA);
            Thread threadB = new Thread(LockB);
            threadA.Start();
            threadB.Start();
            Thread.Sleep(4000);
            Console.WriteLine("线程结束");
        }

        #endregion 实现2

        #region Mutex

        private class ShareRes
        {
            public static int Count;
            public static readonly Mutex SMutex = new Mutex();
        }

        private class IncThread
        {
            private int _number;
            public readonly Thread Thrd;

            public IncThread(string name, int n)
            {
                Thrd = new Thread(Run);
                _number = n;
                Thrd.Name = name;
                Thrd.Start();
            }

            private void Run()
            {
                Console.WriteLine(Thrd.Name + "正在等待 the mutex");
                //申请
                ShareRes.SMutex.WaitOne();
                Console.WriteLine(Thrd.Name + "申请到 the mutex");
                do
                {
                    Thread.Sleep(1000);
                    ShareRes.Count++;
                    Console.WriteLine("In " + Thrd.Name + "ShareRes.count is " + ShareRes.Count);
                    _number--;
                } while (_number > 0);
                Console.WriteLine(Thrd.Name + "释放 the nmutex");
                // 释放
                ShareRes.SMutex.ReleaseMutex();
            }
        }

        private class DecThread
        {
            private int _number;
            public readonly Thread Thrd;

            public DecThread(string name, int n)
            {
                Thrd = new Thread(Run);
                _number = n;
                Thrd.Name = name;
                Thrd.Start();
            }

            private void Run()
            {
                Console.WriteLine(Thrd.Name + "正在等待 the mutex");
                //申请
                ShareRes.SMutex.WaitOne();
                Console.WriteLine(Thrd.Name + "申请到 the mutex");
                do
                {
                    Thread.Sleep(1000);
                    ShareRes.Count--;
                    Console.WriteLine("In " + Thrd.Name + "ShareRes.count is " + ShareRes.Count);
                    _number--;
                } while (_number > 0);
                Console.WriteLine(Thrd.Name + "释放 the nmutex");
                // 释放
                ShareRes.SMutex.ReleaseMutex();
            }
        }

        public static void Demo3()
        {
            IncThread mthrd1 = new IncThread("IncThread thread ", 5);
            DecThread mthrd2 = new DecThread("DecThread thread ", 5);
            mthrd1.Thrd.Join();
            mthrd2.Thrd.Join();
        }

        #endregion Mutex

        #region 多线程

        public class CusThread
        {
            public ParameterizedThreadStart CallBackFunc { get; set; }

            public CusThread(ParameterizedThreadStart start)
            {
                CallBackFunc = start;
            }

            public void Start(object obj)
            {
                CallBackFunc(obj);
            }
        }

        public static void CusThread_Demo()
        {
            CusThread thread1 = new CusThread(o =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i);
                }
            });

            CusThread thread2 = new CusThread(delegate (object o)
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i);
                }
            });

            CusThread thread3 = new CusThread(Function);

            CusThread thread4 = new CusThread(new ParameterizedThreadStart(Function));
        }

        private static void Function(object o1)
        {
            throw new NotImplementedException();
        }

        #endregion 多线程

        #region MyRegion

        protected static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        private static void WriteContentToFile(string cmdfilename, string[] lines)
        {
            if (!File.Exists(cmdfilename))
            {
                File.Create(cmdfilename);
            }
            retray:
            if (!IsFileLocked(new FileInfo(cmdfilename)))
            {
                string content = "";
                foreach (string str in lines)
                {
                    content += str + "\n";
                }
                File.WriteAllText(cmdfilename, content);
            }
            else
            {
                goto retray;
            }
        }

        private static void RunCMDScript(object scriptPath)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(scriptPath.ToString());
            // Now we create a process, assign its ProcessStartInfo and start it
            Process proc = new Process { StartInfo = procStartInfo };
            proc.Start();
        }

        public static void RunCMDDemo()
        {
            char c = '"';
            string[] cmdarr = { "cd /", "C:", "dir", string.Format("cd {0}Program Files{0}", c), "dir", "pause" };

            string filename = Path.Combine(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName, "Resource", "testcmd.cmd");

            string basePath = AppDomain.CurrentDomain.BaseDirectory + "";
            WriteContentToFile(filename, cmdarr);
            Thread objThread = new Thread(RunCMDScript)
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal
            };
            objThread.Start(filename);
        }

        #endregion MyRegion
    }
}