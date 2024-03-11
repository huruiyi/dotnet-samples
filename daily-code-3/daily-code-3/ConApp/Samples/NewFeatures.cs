using System;
using System.Collections.Generic;
using System.Linq;

namespace ConApp.Samples
{
    public class NewFeatures
    {
        public enum Standing
        {
            Freshman, Oldman
        }

        public class Person
        {
            public Person()
            {
            }

            public Person(string firstname)
            {
                this.FirstName = firstname;
                this.FirstNameNew = firstname;
            }

            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.FirstNameNew = lastName;
            }

            public string Namge { get; set; }

            public string FirstName { get; private set; }

            public string LastName { get; private set; }

            public string OldFullName
            {
                get
                {
                    return string.Format("{0} {1}", FirstName, LastName);
                }
            }

            public string FullName => $"{FirstName} {LastName}";

            public string FirstNameNew { get; }

            public string LastNameNew { get; }

            public ICollection<double> Grades { get; } = new List<double>();

            public Standing YearInSchool { get; set; } = Standing.Freshman;

            public void ChangeName(string newLastName)
            {
                LastName = newLastName;
            }

            public override string ToString() => $"{LastName}, {FirstName}";

            public bool MakesDeansList()
            {
                return Grades.All(g => g > 3.5) && Grades.Any();
                // Code below generates CS0103:
                // The name 'All' does not exist in the current context.
                //return All(Grades, g => g > 3.5) && Grades.Any();
            }
        }

        private static void Demo(string[] args)
        {
            long Id = 123456789;
            Console.WriteLine(Id.ToString("N"));

            if (String.IsNullOrEmpty(""))
            {
                Console.WriteLine("using static System.String; IsNullOrEmpty  ");
            }
            Person p2 = new Person("FirstName", null);

            string firstname = p2?.FirstName;
            firstname = p2?.FirstName ?? "Unspecified";
            Console.WriteLine(firstname);

            string lastname = p2?.LastName;
            lastname = p2?.LastName ?? "Unspecified";
            Console.WriteLine(lastname);

            p2.ChangeName("lastname");

            string name = null;
            string n = name ?? "name is null";
            Console.WriteLine(n);
        }
    }
}
