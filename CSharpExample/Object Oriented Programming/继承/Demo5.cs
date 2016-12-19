using System;

namespace InheritSample5
{
    public abstract class Person
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

    public class Studnet : Person
    {
        public Studnet()
        {
        }

        public string Course { get; set; }

        public Studnet(string name, string sex, int age, string course)
            : base(name, sex, age)
        {
            Course = course;
        }

        public void ShowStuInfo()
        {
            Console.WriteLine("(student)我叫：" + Name + "性别：" + Sex + "，爱好学科：" + Course);
        }

        //实现抽象类
        public override void Study()
        {
            Console.WriteLine("学生会学习");
        }

        //对父类中的虚方法进行重写(非必须)
        public override void Speak()
        {
            Console.WriteLine("对Person类中abstract方法进行重写");
        }
    }

    public class Teacher : Person
    {
        public Teacher()
        {
        }

        public Teacher(string name, string sex, int age, string salary)
            : base(name, sex, age)
        {
            Salary = salary;
        }

        public string Salary { get; set; }

        //实现抽象类
        public override void Study()
        {
            Console.WriteLine("老师会学习");
        }
    }

    public class Demo5
    {
        private static void Main(string[] args)
        {
            Studnet s1 = new Studnet("柯南", "男", 19, "英语");
            s1.ShowInfo();
            s1.ShowStuInfo();
            s1.Speak();
            s1.Study();
            Console.WriteLine("++++++++++++++++++++++++++++++");
            Teacher t1 = new Teacher("李四", "男", 30, "20000");
            t1.ShowInfo();
            t1.Speak();
            t1.Study();
            Console.WriteLine("++++++++++++++++++++++++++++++");
            Person p1 = new Studnet("柯南", "男", 19, "英语");
            p1.Speak();
            Person p2 = new Teacher("柯南", "男", 19, "英语");
            p2.Speak();
            Console.ReadKey();
        }
    }
}