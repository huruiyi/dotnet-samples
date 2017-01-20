using System.Collections;

namespace ConApp.Model
{
    public class MyCollection1 : IEnumerable
    {
        public int[] Arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Arr1.Length; i++)
            {
                yield return Arr1[i];
            }
        }
    }
}