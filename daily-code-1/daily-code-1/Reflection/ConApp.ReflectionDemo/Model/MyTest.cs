using System;

namespace ConApp.ReflectionDemo.Model
{
    [Myself("Emma", 25, Memo = "Emma is my good girl.")]
    public class MyTest
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, my.net world.");
        }
    }
}