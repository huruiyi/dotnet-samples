using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Person
    {
        static Person()
        {
            //静态方法只有第一次实例化函数时被调用
            Console.WriteLine("伟大的人类诞生了");
        }
        public Person() { }
        public Person(string name, string sex, int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Sex;
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        private int _Age;
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
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
