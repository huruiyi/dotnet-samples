using System;

namespace ConApp.Class
{
    public class TestClass
    {
        public string P1 { get; set; }

        public int P2 { get; set; }

        public void M1()
        {
            Console.WriteLine("MI1....");
        }

        public string M2()
        {
            return string.Format("{0}:{1}", this.P1, this.P2);
        }

        public static void M2(string s)
        {
            Console.WriteLine(s);
        }

        protected string M2(string s, string s1)
        {
            return s + s1;
        }
    }
}