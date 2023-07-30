using System;
using System.Text;

namespace ConApp
{
    public class StringDemo
    {
        public static void StringReplace1()
        {
            string greetingText = "Hello from all the guys at Wrox Press. ";
            greetingText += "We do hope you enjoy this book as much as we enjoyed writing it.";

            for (int i = 'z'; i >= 'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingText = greetingText.Replace(old1, new1);
            }

            for (int i = 'Z'; i >= 'A'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingText = greetingText.Replace(old1, new1);
            }

            Console.WriteLine("Encoded:\n" + greetingText);
        }

        public static void StringReplace2()
        {
            StringBuilder greetingBuilder = new StringBuilder("Hello from all the guys at Wrox Press. ", 150);
            greetingBuilder.Append("We do hope you enjoy this book as much as we enjoyed writing it");

            for (int i = (int)'z'; i >= (int)'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }

            for (int i = (int)'Z'; i >= (int)'A'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }

            Console.WriteLine("Encoded:\n" + greetingBuilder);
        }

        public static void StringReplace3()
        {
            string greetingText = "Hello from all the guys at Wrox Press. ";

            greetingText += "We do hope you enjoy this book as much as we enjoyed writing it.";

            for (int i = 'z'; i >= (int)'a'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingText = greetingText.Replace(Old, New);
            }

            for (int i = 'Z'; i >= (int)'A'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingText = greetingText.Replace(Old, New);
            }
            Console.WriteLine("Encoded:\n" + greetingText);

            StringBuilder greetingBuilder = new StringBuilder("Hello from all the guys at Wrox Press. ", 150);
            greetingBuilder.Append("We do hope you enjoy this book as much as we enjoyed writing it");

            for (int i = (int)'z'; i >= (int)'a'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(Old, New);
            }

            for (int i = (int)'Z'; i >= (int)'A'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(Old, New);
            }
            Console.WriteLine("Encoded:\n" + greetingBuilder);
        }

        public static void StringSplit()
        {
            string longStr = @"标准通用标记语言下的一个应用HTML标准自1999年12月发布的HTML4.01后，后继的HTML5和其它标准被束之高阁，为了推动Web标准化运动的发展，一些公司联合起来，成立了一个叫做 Web Hypertext Application Technology Working Group （Web超文本应用技术工作组 -WHATWG） 的组织。WHATWG 致力于 Web 表单和应用程序，而W3C（World Wide Web Consortium，万维网联盟） 专注于XHTML2.0。在 2006 年，双方决定进行合作，来创建一个新版本的 HTML。";

            int count = (int)Math.Ceiling(longStr.Length / 100.0);
            string[] logStr = new string[count];

            for (int i = 0; i < count; i++)
            {
                if (i + 1 == count)
                {
                    logStr[i] = longStr.Substring(100 * i);
                }
                else
                {
                    logStr[i] = longStr.Substring(100 * i, 100);
                }
            }

            Console.WriteLine("原始");
            Console.WriteLine(longStr);
            Console.WriteLine("+++++++++++++++++++++++++++++++");
            foreach (string item in logStr)
            {
                Console.Write(item);
            }
        }

        public static string ReverseDemo(string str)
        {
            //反转字符串
            char[] arr = str.ToCharArray();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                char tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
            //string s = new string(arr);
            return string.Join("", arr);
        }
    }
}