using System;

namespace ConApp.ReflectionDemo.Model
{
    public class MyTester
    {
        [Test("Error Here.")]
        public void CannotRun()
        {
            Console.WriteLine("CannotRun.............");
        }

        [ValidateAge(MaxAge = 99)]
        public int Age { get; set; }

        public void Test()
        {
            Console.WriteLine("Age=" + Age);
        }
    }
}