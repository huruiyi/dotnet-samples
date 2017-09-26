using System;

namespace EventDemo01
{
    public class CarInfoEventArgs : EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }

        public string Car { get; private set; }
    }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine("CarDealer, new car {0}", car);
            RaiseNewCarInfo(car);
        }

        protected virtual void RaiseNewCarInfo(string car)
        {
            EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
            if (newCarInfo != null)
            {
                newCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }

    public class Consumer
    {
        private string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine("{0}: car {1} is new", name, e.Car);
        }
    }

    public class Program
    {
        private static void Main01()
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

            Console.ReadKey();
        }
    }
}

namespace EventDemo02
{
    public class NewspaperOffice
    {
        public event Action<string> OnNewspaperPrint;

        public void PrintNewspaper(string content)
        {
            if (OnNewspaperPrint != null)
            {
                OnNewspaperPrint(content);
            }
        }

        public string Name { get; set; }

        public NewspaperOffice(string name)
        {
            Name = name;
        }
    }

    public class NewspaperReader
    {
        public void SubscribeNewspaper(NewspaperOffice office)
        {
            office.OnNewspaperPrint += Read;
            Console.WriteLine("{0}订阅了{1}报纸", Name, office.Name);
        }

        public void UnSubscribeNewspaper(NewspaperOffice office)
        {
            office.OnNewspaperPrint -= Read;
            Console.WriteLine("{0},退订了{1}报纸", Name, office.Name);
        }

        public void Read(string content)
        {
            Console.WriteLine("{0}正在读报纸,内容为：{1}", Name, content);
        }

        public string Name { get; set; }

        public NewspaperReader(string name)
        {
            Name = name;
        }
    }

    internal class Program
    {
        private static void Main02(string[] args)
        {
            NewspaperOffice xinHua = new NewspaperOffice("新华日报");
            NewspaperOffice wuxiShang = new NewspaperOffice("无锡商报");

            NewspaperReader xiaoLiu = new NewspaperReader("小刘");
            NewspaperReader xiaoWang = new NewspaperReader("小王");

            xiaoLiu.SubscribeNewspaper(xinHua);
            xiaoWang.SubscribeNewspaper(xinHua);
            xiaoWang.SubscribeNewspaper(wuxiShang);

            xinHua.PrintNewspaper("2013-08-09日报，内容..........");
            wuxiShang.PrintNewspaper("2013-08-10,内容..........");

            xiaoWang.UnSubscribeNewspaper(xinHua);
            xinHua.PrintNewspaper("2013-08-11日报，内容..........");
            wuxiShang.PrintNewspaper("2013-08-12,内容..........");

            Console.ReadKey();
        }
    }
}

namespace EventDemo03
{
    public class NewspaperEventArgs : EventArgs
    {
        public string Content { get; set; }

        public NewspaperEventArgs()
        {
        }

        public NewspaperEventArgs(string content)
        {
            Content = content;
        }
    }

    public class NewspaperOffice
    {
        public event EventHandler<NewspaperEventArgs> OnNewspaperPrint;

        public void PrintNewspaper(string content)
        {
            if (OnNewspaperPrint != null)
            {
                OnNewspaperPrint(this, new NewspaperEventArgs(content));
            }
        }

        public string Name { get; set; }

        public NewspaperOffice(string name)
        {
            Name = name;
        }
    }

    public class NewspaperReader
    {
        public void SubscribeNewspaper(NewspaperOffice office)
        {
            office.OnNewspaperPrint += Read;
            Console.WriteLine("{0}订阅了{1}报纸", Name, office.Name);
        }

        public void UnSubscribeNewspaper(NewspaperOffice office)
        {
            office.OnNewspaperPrint -= Read;
            Console.WriteLine("{0},退订了{1}报纸", Name, office.Name);
        }

        public void Read(object sender, NewspaperEventArgs e)
        {
            var office = sender as NewspaperOffice;
            if (office != null)
                Console.WriteLine("{0}正在读{1},报纸内容为：{2}", Name, office.Name, e.Content);
        }

        public string Name { get; set; }

        public NewspaperReader(string name)
        {
            Name = name;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            NewspaperOffice xinHua = new NewspaperOffice("新华日报");
            NewspaperOffice wuxiShang = new NewspaperOffice("无锡商报");

            NewspaperReader xiaoLiu = new NewspaperReader("小刘");
            NewspaperReader xiaoWang = new NewspaperReader("小王");

            xiaoLiu.SubscribeNewspaper(xinHua);
            xiaoWang.SubscribeNewspaper(xinHua);
            xiaoWang.SubscribeNewspaper(wuxiShang);

            xinHua.PrintNewspaper("2013-08-09日报，内容..........");
            wuxiShang.PrintNewspaper("2013-08-10,内容..........");

            xiaoWang.UnSubscribeNewspaper(xinHua);
            xinHua.PrintNewspaper("2013-08-11日报，内容..........");
            wuxiShang.PrintNewspaper("2013-08-12,内容..........");

            Console.ReadKey();
        }
    }
}