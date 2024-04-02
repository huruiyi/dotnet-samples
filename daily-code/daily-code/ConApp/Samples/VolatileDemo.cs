using System;
using ConApp.Model;

namespace ConApp.Samples
{
    public class VolatileDemo
    {
        public static void DoAction()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            System.Threading.Thread workerThread = new System.Threading.Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive)

                // Put the main thread to sleep for 1 millisecond to
                // allow the worker thread to do some work.
                System.Threading.Thread.Sleep(1);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }
    }
}