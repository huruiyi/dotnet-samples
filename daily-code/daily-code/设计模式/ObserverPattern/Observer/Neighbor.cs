using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Neighbor : IObserver
    {
        public void Awake()
        {
            Console.WriteLine("{0} Awake", this.GetType().Name);
        }

        public void Action()
        {
            this.Awake();
        }
    }
}