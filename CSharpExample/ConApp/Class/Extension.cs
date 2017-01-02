using System;

namespace ConApp.Class
{
    public class Extension
    {
        public static bool MyCalc(string str)
        {
            if (int.Parse(str) >= 2)
            {
                return true;
            }
            return false;
        }

        public static void UpdateUserInterface()
        {
            Console.Write("运行中。。。。。");

            Console.ReadKey();
        }

        public static bool AutoUpdate()
        {
            return true;
        }

        public static void AutoUpdateSupplierMcScoreAsyncCallback(IAsyncResult ar)
        {
            Func<bool> pc = (Func<bool>)ar.AsyncState;
            var endInvoke = pc.EndInvoke(ar);
            if (endInvoke)
            {
            }
            else
            {
                //执行异常
            }
        }
    }
}