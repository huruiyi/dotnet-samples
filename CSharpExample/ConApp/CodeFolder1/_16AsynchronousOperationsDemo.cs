using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace ConApp.CodeFolder1
{
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }

    public delegate string AsyncMethodCaller(int callDuration, out int threadId);

    internal class _16AsynchronousOperationsDemo
    {
        private static void Main09(string[] args)
        {
            #region Demo1

            //int threadId;
            //AsyncDemo ad = new AsyncDemo();
            //AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);
            //IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);
            //Thread.Sleep(3000);
            //Console.WriteLine("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);
            //string returnValue = caller.EndInvoke(out threadId, result);
            //Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, returnValue);
            //Console.ReadKey();

            #endregion Demo1

            #region Demo2

            //int threadId;
            //AsyncDemo ad = new AsyncDemo();
            //AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);
            //IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);
            //Thread.Sleep(0);
            //Console.WriteLine("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);
            //result.AsyncWaitHandle.WaitOne();
            //string returnValue = caller.EndInvoke(out threadId, result);
            //result.AsyncWaitHandle.Close();
            //Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, returnValue);

            //Console.ReadKey();

            #endregion Demo2

            #region Demo3

            //int threadId;
            //AsyncDemo ad = new AsyncDemo();
            //AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);
            //IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);
            //while (result.IsCompleted == false)
            //{
            //    Thread.Sleep(250);
            //    Console.Write(".");
            //}

            //string returnValue = caller.EndInvoke(out threadId, result);
            //Console.WriteLine("\nThe call executed on thread {0}, with return value \"{1}\".", threadId, returnValue);

            #endregion Demo3

            #region Demo4

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            // The threadId parameter of TestMethod is an out parameter, so
            // its input value is never used by TestMethod. Therefore, a dummy
            // variable can be passed to the BeginInvoke call. If the threadId
            // parameter were a ref parameter, it would have to be a class-
            // level field so that it could be passed to both BeginInvoke and
            // EndInvoke.
            int dummy = 0;

            // Initiate the asynchronous call, passing three seconds (3000 ms)
            // for the callDuration parameter of TestMethod; a dummy variable
            // for the out parameter (threadId); the callback delegate; and
            // state information that can be retrieved by the callback method.
            // In this case, the state information is a string that can be used
            // to format a console message.
            IAsyncResult result = caller.BeginInvoke(3000,
                out dummy,
                new AsyncCallback(CallbackMethod),
                "The call executed on thread {0}, with return value \"{1}\".");

            Console.WriteLine("The main thread {0} continues to execute...",
                Thread.CurrentThread.ManagedThreadId);

            // The callback is made on a ThreadPool thread. ThreadPool threads
            // are background threads, which do not keep the application running
            // if the main thread ends. Comment out the next line to demonstrate
            // this.
            Thread.Sleep(4000);

            Console.WriteLine("The main thread ends.");

            #endregion Demo4
        }

        private static void CallbackMethod(IAsyncResult ar)
        {
            // Retrieve the delegate.
            AsyncResult result = (AsyncResult)ar;
            AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;

            // Retrieve the format string that was passed as state information
            string formatString = (string)ar.AsyncState;

            // Define a variable to receive the value of the out parameter.
            // If the parameter were ref rather than out then it would have to be a class-level field so it could also be passed to BeginInvoke.
            int threadId = 0;

            // Call EndInvoke to retrieve the results.
            string returnValue = caller.EndInvoke(out threadId, ar);

            // Use the format string to format the output message.
            Console.WriteLine(formatString, threadId, returnValue);
        }
    }
}