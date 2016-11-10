using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPTest
{
    [MyAOP]
    public class AOPClassTest : ContextBoundObject
    {
        public object MethodName(string str1, string str2)
        {
            Console.WriteLine("Print方法");
            return str1 + str2 + "Hello";
        }
    }
}