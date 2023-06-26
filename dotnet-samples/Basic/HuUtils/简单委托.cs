using System;
using System.Windows.Forms;
using HuUtils.Model;

namespace HuUtils
{
    public partial class 简单委托 : Form
    {
        public 简单委托()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 泛型委托
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public delegate int DgCompare<T>(T t1, T t2);

        public T GetMax<T>(T[] arr, DgCompare<T> dgCompare)
        {
            T max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (dgCompare(arr[i], max) == 1)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        private int Compare(int a, int b)
        {
            return a > b ? 1 : 0;
        }

        private int Compare(Person a, Person b)
        {
            return a.Age > b.Age ? 1 : 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = { 12, 13, 15, 12, 131, 61, 51, 21 };
            Person[] pers =
            {
                new Person {Name = "刘德华", Age = 50},
                new Person {Name = "张三丰", Age = 100},
                new Person {Name = "张无忌", Age = 16}
            };
            MessageBox.Show(GetMax(arr, Compare).ToString());
            Person maxPer = GetMax(pers, Compare);
            MessageBox.Show(maxPer.Age.ToString());
        }

        public Person GetMax(Person[] per)
        {
            Person max = per[0];
            for (int i = 1; i < per.Length; i++)
            {
                if (max.Age < per[i].Age)
                {
                    max = per[i];
                }
            }
            return max;
        }

        public int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] arr = { 12, 13, 15, 12, 131, 61, 51, 21 };
            MessageBox.Show(GetMax(arr).ToString());

            Person[] pers =
            {
                new Person {Name = "刘德华", Age = 50},
                new Person {Name = "张三丰", Age = 100},
                new Person {Name = "张无忌", Age = 16}
            };
            Person maxAge = GetMax(pers);
            MessageBox.Show(maxAge.Age.ToString());
        }
    }
}