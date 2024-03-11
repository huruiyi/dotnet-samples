using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Mouse : IObserver
    {
        public void Run()
        {
            Console.WriteLine("{0} Run", this.GetType().Name);
        }

        public void Action()
        {
            this.Run();
        }
    }
}