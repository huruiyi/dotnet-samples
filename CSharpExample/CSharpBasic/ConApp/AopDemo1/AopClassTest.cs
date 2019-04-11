using System;

namespace ConApp.AopDemo1
{
    [MyAop]
    public class AopClassTest : ContextBoundObject
    {
        public object MethodName(string str1, string str2)
        {
            Console.WriteLine("Print方法");
            return str1 + str2 + "Hello";
        }
    }
}