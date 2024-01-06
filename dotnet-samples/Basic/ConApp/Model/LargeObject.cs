using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConApp.Model
{
    public class LargeObject
    {
        int initBy = 0;
        public int InitializedBy { get { return initBy; } }

        public LargeObject()
        {
            initBy = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(@"LargeObject was created on thread id {0}.", initBy);
        }
        public long[] Data = new long[100000000];
    }
}
