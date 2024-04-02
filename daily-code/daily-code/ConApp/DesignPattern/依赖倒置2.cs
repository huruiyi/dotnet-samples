using System;

namespace 依赖倒置2
{
    public class AutoSystem
    {
        private readonly ICar _car;

        public AutoSystem(ICar car)
        {
            this._car = car;
        }

        public void RunCar()
        {
            _car.Run();
        }

        public void StopCar()
        {
            _car.Stop();
        }

        public void TurnCar()
        {
            _car.Turn();
        }
    }

    public class FordCar : ICar
    {
        public void Run()
        {
            Console.WriteLine("FordCar run");
        }

        public void Stop()
        {
            Console.WriteLine("FordCar stop");
        }

        public void Turn()
        {
            Console.WriteLine("FordCar turn");
        }
    }

    public class HondaCar : ICar
    {
        public void Run()
        {
            Console.WriteLine("HondaCar run");
        }

        public void Stop()
        {
            Console.WriteLine("HondaCar stop");
        }

        public void Turn()
        {
            Console.WriteLine("HondaCar turn");
        }
    }

    public interface ICar
    {
        void Run();

        void Stop();

        void Turn();
    }

    internal class 依赖倒置2
    {
        private static void Test()
        {
            ICar iCar = new FordCar();
            iCar.Run();
        }
    }
}