using System;

namespace ConApp.Samples
{
    public class WorkerDemo
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("Worker thread: working...");
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        // Keyword volatile is used as a hint to the compiler that this data member is accessed by multiple threads.
        private volatile bool _shouldStop;
    }
}