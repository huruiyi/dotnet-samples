using System;
using System.Collections.Generic;

namespace 解释器模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Context context = new Context();
            IList<AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            Console.Read();
        }
    }

    internal class Context
    {
        private string input;

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        private string output;

        public string Output
        {
            get { return output; }
            set { output = value; }
        }
    }

    internal abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    internal class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }

    internal class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }
}