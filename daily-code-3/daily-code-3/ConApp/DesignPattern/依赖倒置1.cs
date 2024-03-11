using System;

namespace 依赖倒置1
{
    public enum CarType
    {
        Ford, Honda
    };

    public class AutoSystem
    {
        private readonly HondaCar _hcar = new HondaCar();
        private readonly FordCar _fcar = new FordCar();
        private readonly CarType _type;

        public AutoSystem(CarType type)
        {
            this._type = type;
        }

        public void RunCar()
        {
            if (_type == CarType.Ford)
            {
                _fcar.Run();
            }
            else
            {
                _hcar.Run();
            }
        }

        public void TurnCar()
        {
            if (_type == CarType.Ford)
            {
                _fcar.Turn();
            }
            else
            {
                _hcar.Turn();
            }
        }

        public void StopCar()
        {
            if (_type == CarType.Ford)
            {
                _fcar.Stop();
            }
            else
            {
                _hcar.Stop();
            }
        }
    }

    public class FordCar
    {
        public void Run()
        {
            Console.WriteLine("福特开始启动了");
        }

        public void Turn()
        {
            Console.WriteLine("福特开始转弯了");
        }

        public void Stop()
        {
            Console.WriteLine("福特开始停车了");
        }
    }

    public class HondaCar
    {
        public void Run()
        {
            Console.WriteLine("本田开始启动了");
        }

        public void Turn()
        {
            Console.WriteLine("本田开始转弯了");
        }

        public void Stop()
        {
            Console.WriteLine("本田开始停车了");
        }
    }

    public class 依赖倒置1
    {
        private static void Test()
        {
            AutoSystem system = new AutoSystem(CarType.Ford);
            system.RunCar();
        }
    }
}