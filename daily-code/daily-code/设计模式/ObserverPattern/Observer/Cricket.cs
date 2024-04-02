using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Cricket : IObserver
    {
        public void Sing()
        {
            Console.WriteLine("{0} Sing", this.GetType().Name);
        }

        public void Action()
        {
            this.Sing();
        }
    }
}