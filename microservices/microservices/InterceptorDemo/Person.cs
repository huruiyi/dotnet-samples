using System;

namespace InterceptorDemo
{
    public class Person
    {
        [Interceptor]
        public virtual void Say(string msg)
        {
            Console.WriteLine("service calling..." + msg);
        }
    }
}