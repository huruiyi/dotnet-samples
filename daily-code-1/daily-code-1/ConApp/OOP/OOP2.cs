using System;

namespace ConApp.OOP
{
    public class A2
    {
        public A2()
        {
            PrintFields();
        }

        public virtual void PrintFields()
        {
            Console.WriteLine("A：");
        }
    }

    public class B2 : A2
    {
        private int x = 1;
        private int y;

        public B2()
        {
            y = -1;
        }

        public override void PrintFields()
        {
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }

    public class OOP2
    {
        public static void OOP2Test()
        {
            B2 b = new B2();
            Console.WriteLine();
        }
    }
}