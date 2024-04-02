using System;

namespace ConApp.OOP1
{
    public abstract class A
    {
        public A()
        {
            Console.WriteLine("A");
        }

        public virtual void Fun()
        {
            Console.WriteLine("A.Fun()");
        }
    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine("B");
        }

        public new void Fun()
        {
            Console.WriteLine("B.Fun()");
        }

        public static void OOP1Test()
        {
            A a = new B();
            a.Fun();
            Console.WriteLine();
            B b = new B();
            b.Fun();
        }
    }
}