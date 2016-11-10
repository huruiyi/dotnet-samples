using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class MathTest
    {
        public int Value;

        public int GetSquare()
        {
            return Value * Value;
        }

        public static int GetSquareOf(int x)
        {
            return x * x;
        }

        public static double GetPi()
        {
            return 3.14159;
        }
    }
}