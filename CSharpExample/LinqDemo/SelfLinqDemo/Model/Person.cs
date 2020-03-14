using System;

namespace SelfLinqDemo.Model
{
    public class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }

        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            return p.Name.CompareTo(this.Name);
        }

        public void ShowInfo()
        {
            Console.WriteLine("Name:{0},Age:{1},Sex:{2}", Name, Age, Sex);
        }
    }
}