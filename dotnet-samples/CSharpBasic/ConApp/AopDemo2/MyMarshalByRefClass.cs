using System;
using System.Security.Permissions;

namespace ConApp.AopDemo2
{
    // The class used to obtain Metadata.
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class MyMarshalByRefClass : MarshalByRefObject
    {
        public int MyMethod(string str, double dbl, int i)
        {
            Console.WriteLine("MyMarshalByRefClass.MyMethod {0} {1} {2}", str, dbl, i);
            return 0;
        }
    }
}