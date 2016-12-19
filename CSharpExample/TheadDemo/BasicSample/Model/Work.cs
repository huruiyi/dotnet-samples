using System;

namespace BasicSample.Model
{
    public class Work
    {
        public static void DoWork()
        {
            Console.WriteLine("Static thread procedure.");
        }

        public int Data;

        public void DoMoreWork()
        {
            Console.WriteLine("Instance thread procedure. Data={0}", Data);
        }
    }
}