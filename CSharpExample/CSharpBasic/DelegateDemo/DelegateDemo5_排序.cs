using System;

namespace DelegateDemo
{
    internal class DelegateDemo5_排序 : IDelegateDemo
    {
        internal delegate int DelCompare(object o1, object o2);

        private static int PersonCompare(object o1, object o2)
        {
            Person p1 = o1 as Person;
            Person p2 = o2 as Person;
            return p1.Age - p2.Age;
        }

        //字符串从大到小排序
        private static int StringCompare(object o1, object o2)
        {
            string s1 = o1.ToString();
            string s2 = o2.ToString();
            return s2.Length - s1.Length;
        }

        //整数从小到大
        private static int IntCompare(object o1, object o2)
        {
            int i1 = (int)o1;
            int i2 = (int)o2;
            return i1 - i2;
        }

        //从小到大的排序
        private static void Sort(object[] arr, DelCompare del)
        {
            //冒泡的趟数
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //两两比较的次数
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (del(arr[j], arr[j + 1]) > 0)
                    {
                        object tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }

        public void Invoke()
        {
            ////对整数排序
            //object[] arr = { 6, 7, 4, 1, 5 };
            //DelCompare del = IntCompare;
            ////调用排序的方法
            //Sort(arr, del);
            //foreach (object item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            ////对字符串排序
            //object[] arr1 = { "123", "ab", "1", "abcded" };
            //DelCompare del1 = StringCompare;
            //Sort(arr1, del1);
            //foreach (object item in arr1)
            //{
            //    Console.WriteLine(item);
            //}

            //对Person排序
            object[] per = {
                           new Person("laoyang",18),
                           new Person("laosu",17),
                           new Person("laozou",16)
                           };
            DelCompare del = PersonCompare;
            Sort(per, del);
            foreach (Person item in per)
            {
                Console.WriteLine(item.Age);
            }
        }
    }
}