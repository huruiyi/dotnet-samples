using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class MyCollection2 : IEnumerable
    {
        public int[] Arr1 = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(Arr1);
        }
    }
}