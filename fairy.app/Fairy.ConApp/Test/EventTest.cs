using System;
using Fairy.ConApp.Event;
using static Fairy.ConApp.Event.PropertyEventsSample;

namespace Fairy.ConApp.Test
{
    public class EventTest
    {
        public static void Delegate1Method(int i)
        {
            Console.WriteLine(i);
        }

        public static void Delegate2Method(string s)
        {
            Console.WriteLine(s);
        }

        private static void Test()
        {
            PropertyEventsSample p = new PropertyEventsSample();

            p.Event1 += new EventHandler1(Delegate1Method);
            p.Event1 += new EventHandler1(Delegate1Method);
            p.Event1 -= new EventHandler1(Delegate1Method);
            p.RaiseEvent1(2);

            p.Event2 += new EventHandler2(Delegate2Method);
            p.Event2 += new EventHandler2(Delegate2Method);
            p.Event2 -= new EventHandler2(Delegate2Method);
            p.RaiseEvent2("TestString");

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}