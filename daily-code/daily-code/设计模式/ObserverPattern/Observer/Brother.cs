using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Brother : IObserver
    {
        public void Turn()
        {
            Console.WriteLine("{0} Turn", this.GetType().Name);
        }

        public void Action()
        {
            this.Turn();
        }
    }
}