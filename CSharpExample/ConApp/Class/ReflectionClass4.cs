using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class ReflectionClass4
    {
        private int x;
        private int y;

        public ReflectionClass4(int i, int j)
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
            Console.Write("Inside set(int,int).");
            x = a;
            y = b;
            Show();
        }

        public void Set(double a, double b)
        {
            Console.Write("Inside set(double,double).");
            x = (int)a;
            y = (int)b;
            Show();
        }

        public void Show()
        {
            Console.WriteLine("x:{0},y:{1}", x, y);
        }
    }
}