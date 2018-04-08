using System;

namespace ConApp.EventSample.EventDemo1
{
    public class CarInfoEventArgs : EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }

        public string Car { get; }
    }
}