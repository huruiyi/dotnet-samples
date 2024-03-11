using System;
using System.Security.Permissions;

namespace ProxySample
{
    internal class Program
    {
        [PermissionSet(SecurityAction.LinkDemand)]
        private static void Main(string[] args)
        {
            //  ChannelServices.RegisterChannel(new HttpChannel());

            Console.WriteLine("Remoting Sample:");

            Console.WriteLine("Generate a new MyProxy using the Type");
            MyProxy myProxy = new MyProxy(typeof(Service1Client));

            Console.WriteLine("Obtain the transparent proxy from myProxy");
            Service1Client myService = (Service1Client)myProxy.GetTransparentProxy();

            Console.WriteLine("Calling the Proxy");
            string myReturnString = myService.GetData(21345879);

            Console.WriteLine("Checking result : {0}", myReturnString);

            if (myReturnString == "Hi there bill, you are using .NET Remoting")
            {
                Console.WriteLine("myService.HelloMethod PASSED : returned {0}", myReturnString);
            }
            else
            {
                Console.WriteLine("myService.HelloMethod FAILED : returned {0}", myReturnString);
            }
        }
    }
}