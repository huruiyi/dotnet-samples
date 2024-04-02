using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Father : IObserver
    {
        public void Roar()
        {
            Console.WriteLine("{0} Roar", this.GetType().Name);
        }

        public void Action()
        {
            this.Roar();
        }
    }
}