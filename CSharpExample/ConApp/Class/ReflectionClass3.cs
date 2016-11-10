using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class ReflectionClass3
    {
        private int x;
        private int y;

        public ReflectionClass3(int i, int j)
        {
            x = i;
            y = j;
        }

        private int sum()
        {
            return x + y;
        }

        public bool IsBetween(int i)
        {
            if (x < i && i < y) return true;
            else return false;
        }

        public void Set(int a, int b)
        {
            x = a;
            y = b;
        }

        public void Set(double a, double b)
        {
            x = (int)a;
            y = (int)b;
        }

        public void Show()
        {
            Console.WriteLine("x:{0},y:{1}", x, y);
        }
    }
}