using System;

namespace 继承4
{
    internal class 继承4
    {
        private static void Main2(string[] args)
        {
            Dog dog = new Dog("小毛", 3, "蹦蹦跳跳");
            dog.Show();
            Console.ReadKey();
        }
    }

    internal abstract class Pet
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Pet()
        {
        }

        public Pet(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public abstract void Show();
    }

    internal class Dog : Pet
    {
        public string Hobby { get; set; }

        public Dog()
        {
        }

        public Dog(string name, int age, string hobby)
            : base(name, age)
        {
            Hobby = hobby;
        }

        public override void Show()
        {
            Console.WriteLine("狗的名字{0}，年龄{1}，爱好{2}", Name, Age, Hobby);
        }
    }
}