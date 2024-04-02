using System;
using System.Collections.Generic;

namespace 观察者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            s.SubjectState = "ABC";
            s.Notify();

            Console.Read();
        }
    }

    internal abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();

        //增加观察者
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        //移除观察者
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        //通知
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }

    //具体通知者
    internal class ConcreteSubject : Subject
    {
        //具体通知者状态
        public string SubjectState { get; set; }
    }

    internal abstract class Observer
    {
        public abstract void Update();
    }

    internal class ConcreteObserver : Observer
    {
        private string name;
        private string observerState;

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this.Subject = subject;
            this.name = name;
        }

        //更新
        public override void Update()
        {
            observerState = Subject.SubjectState;
            Console.WriteLine("观察者{0}的新状态是{1}",name, observerState);
        }

        public ConcreteSubject Subject { get; set; }
    }
}