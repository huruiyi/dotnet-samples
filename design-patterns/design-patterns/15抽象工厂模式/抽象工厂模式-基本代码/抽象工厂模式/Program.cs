using System;

namespace 抽象工厂模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AbstractFactory factory1 = new ConcreteFactory1();
            Client c1 = new Client(factory1);
            c1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client c2 = new Client(factory2);
            c2.Run();

            Console.Read();
        }
    }

    internal abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();

        public abstract AbstractProductB CreateProductB();
    }

    internal class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    internal class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    internal abstract class AbstractProductA
    {
    }

    internal class ProductA1 : AbstractProductA
    {
    }

    internal class ProductA2 : AbstractProductA
    {
    }

    internal abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    internal class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    internal class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    internal class Client
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;

        // Constructor
        public Client(AbstractFactory factory)
        {
            AbstractProductB = factory.CreateProductB();
            AbstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            AbstractProductB.Interact(AbstractProductA);
        }
    }
}