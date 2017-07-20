using System;

namespace InheritSample3
{
    public abstract class Pet
    {
        public string Name { get; set; }

        public int Age { get; set; }

        protected Pet()
        { }

        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void Show();
    }

    public class Dog : Pet
    {
        public string Hobby { get; set; }

        public Dog(string name, int age, string hobby)
            : base(name, age)
        {
            Hobby = hobby;
        }

        public override void Show()
        {
            Console.WriteLine("name={0},age={1},hobby={2}", Name, Age, Hobby);
        }
    }

    public class Demo3
    {
        private static void Main3(string[] args)
        {
            Dog dog = new Dog("狗", 2, "跳");
            dog.Show();
            Console.ReadKey();
        }
    }
}