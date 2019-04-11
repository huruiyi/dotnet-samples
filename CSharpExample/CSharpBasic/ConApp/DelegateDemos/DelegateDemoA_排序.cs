using System;
using System.Collections.Generic;

namespace ConApp.DelegateDemos
{
    internal class DelegateDemoA_排序 : IDelegateDemo
    {
        internal class Person : IComparable<Person>
        {
            public String Name { get; set; }
            public int Age { get; set; }

            public void Show()
            {
                Console.WriteLine("姓名:" + Name + "年龄:" + Age);
            }

            public int CompareTo(Person other)
            {
                //return this.Age - other.Age;

                //return this.Age.CompareTo(other.Age);

                if (Age > other.Age)
                {
                    return -1;
                }
                if (Age == other.Age)
                {
                    return 0;
                }
                return 1;
            }
        }

        public void Invoke()
        {
            List<Person> per = new List<Person>
            {
                new Person { Name = "A", Age = 11 },
                new Person { Name = "L", Age = 20 },
                new Person { Name = "C", Age = 18 },
                new Person { Name = "E", Age = 19 },
                new Person { Name = "a", Age = 10 },
                new Person { Name = "J", Age = 17 }
            };
            per.ForEach(item => item.Show());
            per.Sort();
            per.ForEach(item => item.Show());
        }
    }
}