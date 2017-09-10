using System;

namespace InheritSample7
{
    
    public class A
    {
        public void a()
        {
            Console.WriteLine("class a");
        }
    }

    public class B : A
    {
        public new void a()
        {
            Console.WriteLine("class b");
        }
    }

    public class Demo7_隐藏
    {
        public static void Main7()
        {
            //隐藏方法

            B b = new B();
            b.a();

            A a = b;
            a.a();
            //输出结果:
            //class b
            //class a
            Console.ReadKey();
        }
    }
}