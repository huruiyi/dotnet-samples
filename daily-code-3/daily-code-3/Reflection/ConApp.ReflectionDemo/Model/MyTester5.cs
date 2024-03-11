using System;

namespace ConApp.ReflectionDemo.Model
{
    public class MyTester5
    {
        public MyTester5()
        {
        }

        public MyTester5(int id)
        {
            this.Id = id;
        }

        public MyTester5(string x)
        {
            this.PInfo = x;
        }

        public string PInfo { get; }

        public int Id { get; set; }

        public string Method(string s1, string s2 = "123")
        {
            return "";
        }

        public string Method(string s1, string s2, string s3)
        {
            return "";
        }

        public void TestMethod0()
        {
            Console.WriteLine("TestMethod0..................");
        }
    }
}