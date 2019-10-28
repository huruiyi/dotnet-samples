using System;
using System.Threading;

namespace DotNet
{

    class LargeObject
    {
        int initBy = 0;
        public int InitializedBy { get { return initBy; } }

        public LargeObject()
        {
            initBy = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("LargeObject was created on thread id {0}.", initBy);
        }
        public long[] Data = new long[100000000];
    }
}