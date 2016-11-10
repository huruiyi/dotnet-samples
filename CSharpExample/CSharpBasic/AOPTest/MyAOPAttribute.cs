using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AOPTest
{
    public class MyAOPAttribute : ContextAttribute, IContributeObjectSink
    {
        public MyAOPAttribute()
            : base("MyAOP")
        {
        }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new MyMessageSink(nextSink);
        }
    }
}