using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Dog : IObserver
    {
        public void Wang(string name)
        {
            Console.WriteLine("{0} Wang", this.GetType().Name);
        }

        public void Action()
        {
            this.Wang("2");
        }
    }
}