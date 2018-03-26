using System;
using System.Collections.Generic;

namespace DelegateDemo
{
    public class DelegateDemoB_查找 : IDelegateDemo
    {
        public class Person
        {
            public String Name { get; set; }
            public int Age { get; set; }

            public void Show()
            {
                Console.WriteLine("姓名:" + Name + "年龄:" + Age);
            }
        }

        public void Invoke()
        {
            List<Person> per = new List<Person>
            {
                new Person {Name = "A", Age = 11},
                new Person {Name = "L", Age = 20},
                new Person {Name = "C", Age = 18},
                new Person {Name = "E", Age = 19},
                new Person {Name = "a", Age = 10},
                new Person {Name = "J", Age = 17}
            };
            per.ForEach(item => item.Show());
            Comparison<Person> com = Comparer;
            per.Sort(com);

            per.ForEach(item => item.Show());
            Predicate<Person> pre = Match;
            per.RemoveAll(pre);

            per.ForEach(item => item.Show());
        }

        private static int Comparer(Person p1, Person p2)
        {
            return p2.Age - p1.Age;
        }

        private static bool Match(Person p)
        {
            if (p.Age <= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}