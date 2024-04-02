using System;
using System.Collections.Generic;

namespace Fairy.ConApp.Event
{
    public class PropertyEventsSample
    {

        public delegate void EventHandler1(int i);
        public delegate void EventHandler2(string s);

        private Dictionary<string, Delegate> eventTable;

        public PropertyEventsSample()
        {
            eventTable = new Dictionary<string, Delegate>
            {
                { "Event1", null },
                { "Event2", null }
            };
        }

        public event EventHandler1 Event1
        {
            add
            {
                lock (eventTable)
                {
                    eventTable["Event1"] = (EventHandler1)eventTable["Event1"] + value;
                }
            }
            remove
            {
                lock (eventTable)
                {
                    eventTable["Event1"] = (EventHandler1)eventTable["Event1"] - value;
                }
            }
        }

        public event EventHandler2 Event2
        {
            add
            {
                lock (eventTable)
                {
                    eventTable["Event2"] = (EventHandler2)eventTable["Event2"] + value;
                }
            }
            remove
            {
                lock (eventTable)
                {
                    eventTable["Event2"] = (EventHandler2)eventTable["Event2"] - value;
                }
            }
        }

        internal void RaiseEvent1(int i)
        {
            EventHandler1 handler1;
            if (null != (handler1 = (EventHandler1)eventTable["Event1"]))
            {
                handler1(i);
            }
        }

        internal void RaiseEvent2(string s)
        {
            EventHandler2 handler2;
            if (null != (handler2 = (EventHandler2)eventTable["Event2"]))
            {
                handler2(s);
            }
        }


    }

     
}