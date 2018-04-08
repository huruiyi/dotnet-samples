using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConApp.EventSample.EventDemo6
{
    /// <summary>
    /// 热水器
    /// </summary>
    public class Heater
    {
        public event EventHandler OnBoiled;
        private void RasieBoiledEvent()
        {
            if (OnBoiled == null)
            {
                Console.WriteLine("加热完成处理订阅事件为空");
            }
            else
            {
                OnBoiled(this, new EventArgs());
            }
        }
        private Thread heatThread;
        public void Begin()
        {
            heatTime = 5;
            heatThread = new Thread(new ThreadStart(Heat));
            heatThread.Start();
            Console.WriteLine("加热器已经开启", heatTime);

        }
        private int heatTime;
        private void Heat()
        {
            while (true)
            {
                Console.WriteLine("加热还需{0}秒", heatTime);

                if (heatTime == 0)
                {
                    RasieBoiledEvent();
                    return;
                }
                heatTime--;
                Thread.Sleep(1000);

            }
        }
    }
}
