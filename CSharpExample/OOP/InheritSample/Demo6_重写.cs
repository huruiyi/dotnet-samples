using System;

namespace InheritSample6
{
    public class A
    {
        public virtual void a()
        {
            Console.WriteLine("class A");
        }
    }

    public class B : A
    {
        public override void a()
        {
            Console.WriteLine("class b");
        }
    }

    public class Demo6_重写
    {
        public static void Main6()
        {
            //重写方法
            B b = new B();
            b.a();

            A a = b;
            a.a();

            //输出结果:
            //class b
            //class b

            Console.ReadKey();
        }
    }
}