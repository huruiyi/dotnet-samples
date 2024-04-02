using System;

namespace 命令模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoker i = new Invoker();

            // Set and execute command
            i.SetCommand(c);
            i.ExecuteCommand();

            Console.Read();
        }
    }

    internal abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        abstract public void Execute();
    }

    internal class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            :
          base(receiver)
        { }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    internal class Receiver
    {
        public void Action()
        {
            Console.WriteLine("执行请求！");
        }
    }

    internal class Invoker
    {
        private Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}