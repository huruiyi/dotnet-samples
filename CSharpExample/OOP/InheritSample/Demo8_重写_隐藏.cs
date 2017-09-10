using System;

namespace InheritSample
{
    public abstract class Person
    {
        public void Say()
        {
            Console.WriteLine("人说");
        }

        public abstract void AbsFunA();

        public virtual void VirFunB()
        {
            Console.WriteLine("Person VirFunB......");
        }

        public virtual void VirFunC()
        {
            Console.WriteLine("Person VirFunC......");
        }
    }

    public class Student : Person
    {
        public override void AbsFunA()
        {
            Console.WriteLine("Student AbsFunA");
        }

        public override void VirFunB()
        {
            Console.WriteLine("Student...VirFunB...");
        }

        public new void VirFunC()
        {
            Console.WriteLine("Student VirFunC");
        }
    }

    internal class Demo8_重写_隐藏
    {
        //抽象类不能实例化
        //抽象方法必须包含在抽象类中
        //如果继承了抽象类,则抽象方法必须重写, 虚方法不必重写

        //svm 快捷方式
        private static void Main(string[] args)
        {
            Person per = new Student();
            per.AbsFunA();
            Console.WriteLine();

            per.VirFunB();
            Console.WriteLine();

            per.VirFunC();
            Console.WriteLine();

            Student stu = new Student();
            stu.AbsFunA();
            Console.WriteLine();

            stu.VirFunB();
            Console.WriteLine();

            stu.VirFunC();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}