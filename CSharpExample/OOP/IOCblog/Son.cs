using System;

namespace IOCblog
{
    //被调用者类 IPerson实现层

    public class Son : IPerson
    {
        public void Operation()
        {
            Console.WriteLine("son is the operator");
        }
    }
}