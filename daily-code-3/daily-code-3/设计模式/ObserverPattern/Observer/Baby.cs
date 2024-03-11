using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Baby : IObserver
    {
        public void Cry()
        {
            Console.WriteLine("{0} Cry", this.GetType().Name);
        }

        public void Action()
        {
            this.Cry();
        }
    }
}