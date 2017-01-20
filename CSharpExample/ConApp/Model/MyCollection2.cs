using System.Collections;

namespace ConApp.Model
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