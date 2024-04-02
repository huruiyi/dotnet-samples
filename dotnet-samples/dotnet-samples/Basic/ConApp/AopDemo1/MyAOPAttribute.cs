using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace ConApp.AopDemo1
{
    public class MyAopAttribute : ContextAttribute, IContributeObjectSink
    {
        public MyAopAttribute()
            : base("MyAOP")
        {
        }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new MyMessageSink(nextSink);
        }
    }
}