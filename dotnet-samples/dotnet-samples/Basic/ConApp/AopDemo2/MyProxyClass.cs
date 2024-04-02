using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security.Permissions;

namespace ConApp.AopDemo2
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class MyProxyClass : RealProxy
    {
        private readonly Object _objInstance;
        private readonly Type _type;

        public MyProxyClass(Type myType) : base(myType)
        {
            // This constructor forwards the call to base RealProxy.
            // RealProxy uses the Type to generate a transparent proxy.
            _type = myType;
            _objInstance = Activator.CreateInstance(myType);
        }

        public override IMessage Invoke(IMessage message)
        {
            IMethodMessage method = (IMethodMessage)message;

            Console.WriteLine("**** Begin Invoke ****");
            Console.WriteLine("\tType is : " + _type);
            Console.WriteLine("\tMethod name : " + method.MethodName);

            for (int i = 0; i < method.ArgCount; i++)
            {
                Console.WriteLine("\tArgName is : " + method.GetArgName(i));
                Console.WriteLine("\tArgValue is: " + method.GetArg(i));
            }

            Console.WriteLine(method.HasVarArgs
                ? "\t The method have variable arguments!!"
                : "\t The method does not have variable arguments!!");

            // Dispatch the method call to the real object.
            Object returnValue = _type.InvokeMember(method.MethodName, BindingFlags.InvokeMethod, null, _objInstance, method.Args);
            Console.WriteLine("**** End Invoke ****");

            // Build the return message to pass back to the transparent proxy.
            ReturnMessage ret = new ReturnMessage(returnValue, null, 0, null, (IMethodCallMessage)message);
            return ret;
        }
    }
}