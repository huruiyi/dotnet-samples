using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AOPTest
{
    public class MyMessageSink : IMessageSink
    {
        private IMessageSink nextSink = null;

        public MyMessageSink(IMessageSink messageSink)
        {
            nextSink = messageSink;
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        public IMessageSink NextSink
        {
            get { return nextSink; }
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            Console.WriteLine("AOP Call Begin");
            IMessage returnMsg = null;

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("开始计时");
            sw.Start();
            returnMsg = nextSink.SyncProcessMessage(msg);
            Console.WriteLine("结束计时");

            sw.Stop();

            IMethodReturnMessage returnMessage = returnMsg as IMethodReturnMessage;
            MethodInfo methodInfo = returnMessage.MethodBase as MethodInfo;

            int argCount = returnMessage.ArgCount;
            Console.WriteLine("方法的输入参数个数:{0}", argCount);
            for (int i = 0; i < argCount; i++)
            {
                var obj = returnMessage.Args[i];
                Console.WriteLine("方法的第{0}参数:名:{1},值:{2}", i + 1, methodInfo.GetParameters()[i].Name, returnMessage.Args[i]);
            }
            Console.WriteLine("方法的返回值:{0}", returnMessage.ReturnValue);

            string returnType = methodInfo.ReturnType.Name;
            ParameterInfo[] ps = methodInfo.GetParameters();

            Exception message = returnMessage.Exception;

            var para = returnMessage.Args;
            Console.WriteLine(string.Format("方法返回值类型:{0}", returnType));
            Console.WriteLine(string.Format("方法名称:{0}", methodInfo.Name));
            Console.WriteLine("AOP Call End");
            return returnMsg;
        }
    }
}