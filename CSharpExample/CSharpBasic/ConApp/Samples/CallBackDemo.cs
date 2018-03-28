using System;

namespace ConApp
{
    public class CallBackDemo
    {
        public interface IBack
        {
            void Run();
        }

        public class CallBack : IBack
        {
            public void Run()
            {
                Console.WriteLine(DateTime.Now);
            }
        }

        public class Controller
        {
            public IBack CallBackObj;

            public Controller(IBack obj)
            {
                this.CallBackObj = obj;
            }

            public void Star()
            {
                Console.WriteLine(@"敲键盘任意键就显示当前的时间，直到按ESC退出....");
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    CallBackObj.Run();
                }
            }
        }

        public static void Demo()
        {
            Controller obj = new Controller(new CallBack());
            obj.Star();
        }
    }
}