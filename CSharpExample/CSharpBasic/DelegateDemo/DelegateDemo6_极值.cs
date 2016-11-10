using System;

namespace DelegateDemo
{
    internal class DelegateDemo6_极值 : IDelegateDemo
    {
        private delegate int DelGetMax<T>(T obj1, T obj2);

        private static int CompareString(string s1, string s2)
        {
            return s1.Length > s2.Length ? 1 : 0;
        }

        private static int ComparePer(Person p1, Person p2)
        {
            return p1.Age > p2.Age ? 1 : 0;
        }

        private static int CompareInt(int a, int b)
        {
            return a > b ? 1 : 0;
        }

        private static T GetMax<T>(T[] arr, DelGetMax<T> del)
        {
            T max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (del(arr[i], max) == 1)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        #region 获取最大值

        //private static int GetMax(int[] arr)
        //{
        //    int max = arr[0];
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i] > max)
        //        {
        //            max = arr[i];
        //        }
        //    }
        //    return max;
        //}

        //private static Person GetMax(Person[] pers)
        //{
        //    Person maxAgePerson = pers[0];
        //    for (int i = 0; i < pers.Length; i++)
        //    {
        //        if (pers[i].Age > maxAgePerson.Age)
        //        {
        //            maxAgePerson = pers[i];
        //        }
        //    }
        //    return maxAgePerson;
        //}

        #endregion 获取最大值

        public void Invoke()
        {
            //获取最大整数
            DelGetMax<int> del1 = CompareInt;
            int[] arr = { 12, 11, 3, 6, 45, 38, 26 };
            Console.WriteLine(GetMax<int>(arr, del1));

            //获取最大年龄的人
            DelGetMax<Person> del2 = ComparePer;
            Person[] pers =
            {
             new Person{Name="A",Age=12},
             new Person{Name="B",Age=18},
             new Person{Name="C",Age=16}
            };
            Console.WriteLine(GetMax<Person>(pers, del2).Name);

            //获取最唱的字符串函数
            DelGetMax<string> del3 = CompareString;
            string[] strs = { "sas", "gdfht", "jgfj", "jygfgfgfgfudhgd", "hgdfhrtdydtry" };
            Console.WriteLine(GetMax<string>(strs, del3));
        }
    }
}