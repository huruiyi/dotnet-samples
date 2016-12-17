using System;

namespace ConsoleApplication1
{
    internal abstract class Person
    {
        static Person()
        {
            //静态方法只有第一次实例化函数时被调用
            Console.WriteLine("伟大的人类诞生了");
        }

        public Person()
        {
        }

        public Person(string name, string sex, int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
        }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        //虚方法可以被重写也可以不重写
        public virtual void Speak()
        {
            Console.WriteLine("我是人我会说话");
        }

        //	抽象方法必须被子类重写
        public abstract void Study();

        public void ShowInfo()
        {
            Console.WriteLine("(person)姓名：" + Name + ",性别：" + Sex + "年龄：" + Age + "\n");
        }
    }
}