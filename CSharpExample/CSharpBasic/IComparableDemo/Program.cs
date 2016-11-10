using System;
using System.Collections.Generic;

namespace IComparableDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Demo1();

            Console.ReadKey();
        }

        private static void Demo1()
        {
            List<PersonA> per = new List<PersonA>
            {
                new PersonA { Name = "A", Age = 11 },
                new PersonA { Name = "L", Age = 20 },
                new PersonA { Name = "C", Age = 18 },
                new PersonA { Name = "E", Age = 19 },
                new PersonA { Name = "a", Age = 10 },
                new PersonA { Name = "J", Age = 17 }
            };

            per.Sort();
            PrintArr(per);
            Console.ReadKey();
        }

        private static void PrintArr(IEnumerable<PersonA> list)
        {
            foreach (PersonA li in list)
            {
                li.Show();
            }
        }

        private static void Demo2()
        {
            List<PersonB> per = new List<PersonB>
            {
                new PersonB {Name = "A", Age = 11},
                new PersonB {Name = "L", Age = 20},
                new PersonB {Name = "C", Age = 18},
                new PersonB {Name = "E", Age = 19},
                new PersonB {Name = "a", Age = 10},
                new PersonB {Name = "J", Age = 17}
            };

            Comparison<PersonB> com = Comparer;
            per.Sort(com);
            PrintArr(per);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
            Predicate<PersonB> pre = Match;
            per.RemoveAll(pre);
            PrintArr(per);
        }

        private static void PrintArr(List<PersonB> list)
        {
            foreach (PersonB li in list)
            {
                li.Show();
            }
        }

        private static int Comparer(PersonB p1, PersonB p2)
        {
            return p2.Age - p1.Age;
        }

        private static bool Match(PersonB p)
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