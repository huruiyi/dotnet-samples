using System;

namespace ConApp.EventSample.EventDemo1
{
    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine($"CarDealer, new car {car}");

            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
}