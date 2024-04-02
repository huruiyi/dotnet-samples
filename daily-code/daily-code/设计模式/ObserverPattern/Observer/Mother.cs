using ObserverPattern.Subject;
using System;

namespace ObserverPattern.Observer
{
    public class Mother : IObserver
    {
        public void Whisper()
        {
            Console.WriteLine("{0} Whisper", this.GetType().Name);
        }

        public void Action()
        {
            this.Whisper();
        }
    }
}