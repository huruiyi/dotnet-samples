using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ConApp
{
    public partial class Program
    {
        public static void Demo0()
        {
            //ConfigurationValidatorBase valBase;

            RegexStringValidatorAttribute rstrValAttr = new RegexStringValidatorAttribute(@"\w+\S*");

            // Get the regular expression string.
            string regex = rstrValAttr.Regex;
            Console.WriteLine("Regular expression: {0}", regex);
        }

        public static void 匹配整形()
        {
            //Regex r = new Regex("\\d{1,}", RegexOptions.Multiline);
            Regex r = new Regex("\\d{1,}", RegexOptions.Multiline);
            Match m = r.Match("abcde213defdf");
            Console.WriteLine(m.Value);
            GroupCollection g = m.Groups;
            while (m.Success)
            {
                Console.WriteLine(m.Value);
                m = m.NextMatch();
            }
        }

        public static void 匹配字符串()
        {
            string text = "One car red car blue car";
            Regex reg = new Regex("\\w+");
            Match m = reg.Match(text);
            Console.WriteLine(m.Value);

            GroupCollection g = m.Groups;
            while (m.Success)
            {
                Console.WriteLine(m.Value);
                m = m.NextMatch();
            }
        }

        public static void 按组匹配()
        {
            string text = "One car red car blue car";
            string pat = @"(\w+)\s+(car)";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(text);
            int matchCount = 0;
            while (m.Success)
            {
                Console.WriteLine("Match" + (++matchCount));
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    Console.WriteLine("Group" + i + "='" + g + "'");
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        System.Console.WriteLine("Capture" + j + "='" + c + "', Position=" + c.Index);
                    }
                }
                m = m.NextMatch();
                Console.WriteLine();
            }
        }
    }
}