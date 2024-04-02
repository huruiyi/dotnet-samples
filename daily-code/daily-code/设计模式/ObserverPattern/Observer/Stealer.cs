using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Stealer : IObserver
    {
        public void Hide()
        {
            Console.WriteLine("{0} Hide", this.GetType().Name);
        }

        public void Action()
        {
            this.Hide();
        }
    }
}