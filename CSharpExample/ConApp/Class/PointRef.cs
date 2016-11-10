using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class PointRef  // <= Renamed and retyped.
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
}