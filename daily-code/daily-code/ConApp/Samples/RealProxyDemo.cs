using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security.Permissions;

namespace ConApp.Samples
{
    // MyProxy extends the CLR Remoting RealProxy.
    // In the same class, in the Invoke method, the methods and properties of the
    // IMethodCallMessage are demonstrated.

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class MyProxy : RealProxy
    {
        private MarshalByRefObject myMarshalByRefObject;

        private String stringUri;

        public MyProxy(Type myType) : base(myType)
        {
            myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(myType);
            ObjRef myObject = RemotingServices.Marshal(myMarshalByRefObject);
            stringUri = myObject.URI;
            Console.WriteLine("URI :{0}", myObject.URI);
            // This constructor forwards the call to base RealProxy.
            // RealProxy uses the Type to generate a transparent proxy.
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override IMessage Invoke(IMessage myIMessage)
        {
            Console.WriteLine("**********************************************************************************");

            IDictionary myIDictionary = myIMessage.Properties;
            // Set the '__Uri' property of 'IMessage' to 'URI' property of 'ObjRef'.
            myIDictionary["__Uri"] = stringUri;
            IDictionaryEnumerator myIDictionaryEnumerator = (IDictionaryEnumerator)myIDictionary.GetEnumerator();
            while (myIDictionaryEnumerator.MoveNext())
            {
                Object myKey = myIDictionaryEnumerator.Key;
                String myKeyName = myKey.ToString();
                Object myValue = myIDictionaryEnumerator.Value;

                Console.WriteLine("\t{0} : {1}", myKeyName, myIDictionaryEnumerator.Value);
                if (myKeyName == "__Args")
                {
                    Object[] objs = (Object[])myValue;
                    for (int aIndex = 0; aIndex < objs.Length; aIndex++)
                        Console.WriteLine("\t\targ: {0} myValue: {1}", aIndex, objs[aIndex]);
                }

                if ((myKeyName == "__MethodSignature") && (null != myValue))
                {
                    Object[] objs = (Object[])myValue;
                    for (int aIndex = 0; aIndex < objs.Length; aIndex++)
                        Console.WriteLine("\t\targ: {0} myValue: {1}", aIndex, objs[aIndex]);
                }
            }

            Console.WriteLine("**********************************************************************************");

            Console.WriteLine("ChannelServices.SyncDispatchMessage");
            IMessage myReturnMessage = ChannelServices.SyncDispatchMessage(myIMessage);

            // Push return value and OUT parameters back onto stack.
            IMethodReturnMessage myMethodReturnMessage = (IMethodReturnMessage)myReturnMessage;
            Console.WriteLine("IMethodReturnMessage.ReturnValue: {0}", myMethodReturnMessage.ReturnValue);

            Console.WriteLine("**********************************************************************************");
            IMethodCallMessage myIMethodCallMessage = (IMethodCallMessage)myIMessage;
            IMethodReturnMessage myIMethodReturnMessage = RemotingServices.ExecuteMessage(myMarshalByRefObject, myIMethodCallMessage);
            Console.WriteLine("Method name : " + myIMethodReturnMessage.MethodName);
            Console.WriteLine("The return value is : " + myIMethodReturnMessage.ReturnValue);

            Console.WriteLine("**********************************************************************************");

            int myArgOutCount = myIMethodReturnMessage.OutArgCount;
            Console.WriteLine("The number of 'ref', 'out' parameters are : " + myIMethodReturnMessage.OutArgCount);
            // Gets name and values of 'ref' and 'out' parameters.
            for (int i = 0; i < myArgOutCount; i++)
            {
                Console.WriteLine("Name of argument {0} is '{1}'.", i, myIMethodReturnMessage.GetOutArgName(i));
                Console.WriteLine("Value of argument {0} is '{1}'.", i, myIMethodReturnMessage.GetOutArg(i));
            }
            Console.WriteLine();
            object[] myObjectArray = myIMethodReturnMessage.OutArgs;
            for (int i = 0; i < myObjectArray.Length; i++)
                Console.WriteLine("Value of argument {0} is '{1}' in OutArgs", i, myObjectArray[i]);

            Console.WriteLine("**********************************************************************************");
            Console.WriteLine("Message is of type 'IMethodCallMessage'.");
            Console.WriteLine("InArgCount is  : " + myIMethodCallMessage.InArgCount);
            foreach (object arg in myIMethodCallMessage.InArgs)
            {
                Console.WriteLine("InArgs is : " + arg);
            }
            for (int i = 0; i < myIMethodCallMessage.InArgCount; i++)
            {
                Console.WriteLine("GetArgName(" + i + ") is : " + myIMethodCallMessage.GetArgName(i));
                Console.WriteLine("GetInArg(" + i + ") is : " + myIMethodCallMessage.GetInArg(i));
            }
            Console.WriteLine("**********************************************************************************");
            var message = new ReturnMessage(5, null, 0, null, (IMethodCallMessage)myIMessage);

            return message;
        }
    }

    // The class used to obtain Metadata.
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class MyMarshalByRefClass : MarshalByRefObject
    {
        public int MyMethod(string strValue, double dblValue, int iValue, out string result)
        {
            result = $"MyMarshalByRefClass.MyMethod  Returned Value= {strValue} {dblValue} {iValue}";
            Console.WriteLine(result);
            return 10001;
        }
    }

    // Main class that drives the whole sample.
    public class ProxySample
    {
        [SecurityPermission(SecurityAction.LinkDemand)]
        public static void RealProxyDemo()
        {
            Console.WriteLine("Generate a new MyProxy.");
            MyProxy myProxy = new MyProxy(typeof(MyMarshalByRefClass));

            Console.WriteLine("Obtain the transparent proxy from myProxy.");
            MyMarshalByRefClass myMarshalByRefClassObj = (MyMarshalByRefClass)myProxy.GetTransparentProxy();

            Console.WriteLine("Calling the Proxy.");
            string outResult;
            int myReturnValue = myMarshalByRefClassObj.MyMethod("Microsoft", 1.2, 6, out outResult);
            Console.WriteLine(outResult);

            Console.WriteLine("Sample Done.");
        }
    }
}
