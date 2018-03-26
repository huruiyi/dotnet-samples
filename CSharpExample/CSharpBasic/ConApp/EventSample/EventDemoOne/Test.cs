using System;

namespace ConApp.EventSample.EventDemoOne
{
    public class Test
    {
        public static void Demo1()
        {
            CarDealer dealer = new CarDealer();

            Consumer c1 = new Consumer("Consumer1");
            dealer.NewCarInfo += c1.NewCarIsHere;
            dealer.NewCar("Mercedes");
            Console.WriteLine("\r\n");

            Consumer c2 = new Consumer("Consumer2");
            dealer.NewCarInfo += c2.NewCarIsHere;
            dealer.NewCar("Ferrari");
            Console.WriteLine("\r\n");

            dealer.NewCarInfo -= c2.NewCarIsHere;
            dealer.NewCar("Red Bull Racing");
        }

        public static void Demo2()
        {
            CarDealer dealer = new CarDealer();

            Consumer michael = new Consumer("Consumer1");
            dealer.NewCarInfo += michael.NewCarIsHere;
            dealer.NewCar("Ferrari");

            Consumer nick = new Consumer("Consumer2");
            dealer.NewCarInfo += nick.NewCarIsHere;
            dealer.NewCar("Mercedes");
            dealer.NewCarInfo -= michael.NewCarIsHere;
            dealer.NewCar("Red Bull Racing");
        }
    }
}