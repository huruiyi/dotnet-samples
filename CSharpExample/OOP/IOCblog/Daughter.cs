using System;

namespace IOCblog
{
    //被调用者之二
    public class Daughter : IPerson
    {
        public void Operation()
        {
            Console.WriteLine("daughter is the operator");
        }
    }
}