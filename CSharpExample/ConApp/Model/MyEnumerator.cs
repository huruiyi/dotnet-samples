using System.Collections;

namespace ConApp.Model
{
    public class MyEnumerator : IEnumerator
    {
        public int[] Arr;
        public int index = -1;

        public MyEnumerator(int[] arr)
        {
            Arr = arr;
        }

        public object Current
        {
            get { return Arr[index]; }
        }

        public bool MoveNext()
        {
            index++;
            if (Arr.Length > index)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            index = -1;
        }
    }
}