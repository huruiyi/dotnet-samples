using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    public interface ISay
    {
        string Say();
    }

    [Block(Level.Yes)]
    public class GovermentSay : ISay
    {
        public string Say()
        {
            return "Our country is the most democratic country";
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class BlockAttribute : Attribute
    {
        public Level Level { get; set; }

        public BlockAttribute(Level level)
        {
            Level = level;
        }
    }

    [Block(Level.NO)]
    public class PeopleSay : ISay
    {
        public string Say()
        {
            return "We need human rights";
        }
    }

    public enum Level { NO, Yes }

    public class ThePress
    {
        public static void Print(ISay say)
        {
            System.Reflection.MemberInfo info = say.GetType();
            BlockAttribute att = (BlockAttribute)Attribute.GetCustomAttribute(info, typeof(BlockAttribute));
            if (att.Level == Level.Yes)
            {
                Console.WriteLine(say.GetType() + ": " + say.Say());
            }
            else
            {
                Console.WriteLine(say.GetType() + ": " + "I Love the contry!");
            }
        }
    }

    [Block(Level.NO)]
    public class AttributeDemo
    {
        public static void Demo()
        {
            ISay sayPeople = new PeopleSay();
            ISay sayGoverment = new GovermentSay();
            ThePress.Print(sayPeople);
            ThePress.Print(sayGoverment);
        }
    }
}