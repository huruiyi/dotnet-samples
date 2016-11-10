using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AOPClassTest test1 = new AOPClassTest();
            test1.MethodName("11111", "aaas");

            Console.ReadKey();
        }
    }
}

/*

public override IMessage Invoke(IMessage message)
{
   IMethodMessage myMethodMessage = (IMethodMessage)message;

   Console.WriteLine("**** Begin Invoke ****");
   Console.WriteLine("\tType is : " + myType);
   Console.WriteLine("\tMethod name : " +  myMethodMessage.MethodName);

   for (int i=0; i < myMethodMessage.ArgCount; i++)
   {
      Console.WriteLine("\tArgName is : " + myMethodMessage.GetArgName(i));
      Console.WriteLine("\tArgValue is: " + myMethodMessage.GetArg(i));
   }

   if(myMethodMessage.HasVarArgs)
       Console.WriteLine("\t The method have variable arguments!!");
   else
       Console.WriteLine("\t The method does not have variable arguments!!");

   // Dispatch the method call to the real object.
   Object returnValue = myType.InvokeMember( myMethodMessage.MethodName, BindingFlags.InvokeMethod, null,
                                        myObjectInstance, myMethodMessage.Args );
   Console.WriteLine("**** End Invoke ****");

   // Build the return message to pass back to the transparent proxy.
   ReturnMessage myReturnMessage = new ReturnMessage( returnValue, null, 0, null,
       (IMethodCallMessage)message );
   return myReturnMessage;
}

     */