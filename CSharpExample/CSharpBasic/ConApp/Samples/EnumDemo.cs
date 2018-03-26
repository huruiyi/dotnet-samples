using ConApp.Model;
using System;
using System.ComponentModel;

namespace ConApp.Samples
{
    public class EnumDemo
    {
        /*
            “X”或“x” 以十六进制格式表示 value（不带前导“0x”）。
            “D”或“d” 以十进制形式表示 value。
            “F”或“f” 对于“G”或“g”执行的行为是相同的，只是在 Enum 声明中不需要 FlagsAttribute。

            “G”或“g”
            如果 value 等于某个已命名的枚举常数，则返回该常数的名称；否则返回 value 的等效十进制数。
            例如，假定唯一的枚举常数命名为 Red，其值为 1。如果将 value 指定为 1，则此格式返回“Red”。然而，如果将 value 指定为 2，则此格式返回“2”。
            - 或 -
            如果将 FlagsAttribute 自定义特性应用于枚举，则 value 将被视为位域，该位域包含一个或多个由一位或多位组成的标志。
            如果 value i等于命名枚举常数的组合，则将返回这些常量名的分隔符分隔列表。将在 value 中搜索标志，从具有最大值的标志到具有最小值的标志进行搜索。
            对于与 value 中的位域相对应的每个标志，常数的名称连接到用分隔符分隔的列表。则将不再考虑该标记的值，而继续搜索下一个标志。
            如果 value 不等于已命名的枚举常数的组合，则返回 value 的等效十进制数。
        */

        public static void Demo01()
        {
            Console.WriteLine($"SocialTypeEnum.Facebook={SocialTypeEnum.Facebook}");
            Console.WriteLine($"(int)SocialTypeEnum.Facebook={(int)SocialTypeEnum.Facebook}");

            const int b = (int)SocialTypeEnum.Facebook;
            Console.WriteLine(b);
            Console.WriteLine((SocialTypeEnum)b);

            const SocialTypeEnum s = (SocialTypeEnum)10;
            const int e = (int)s;
            Console.WriteLine(s);
            Console.WriteLine(e);
        }

        public static void Demo02_Parse()
        {
            const string a = "Twitter";
            try
            {
                SocialTypeEnum social = (SocialTypeEnum)(Enum.Parse(typeof(SocialTypeEnum), a));
                Console.WriteLine(@"SocialTypeEnum=" + social);
            }
            catch
            {
                Console.WriteLine(@"无此枚举");
            }
        }

        public static void Demo3_Format()
        {
            SocialTypeEnum s = SocialTypeEnum.GooglePlus;
            Console.WriteLine($@"
                    d={Enum.Format(typeof(SocialTypeEnum), s, "d")}
                    x={Enum.Format(typeof(SocialTypeEnum), s, "x")}
                    g={Enum.Format(typeof(SocialTypeEnum), s, "g")}
                    f={Enum.Format(typeof(SocialTypeEnum), s, "f")}");
            const SocialTypeEnum se = SocialTypeEnum.Facebook | SocialTypeEnum.GooglePlus | SocialTypeEnum.Twitter;
            Console.WriteLine(se);

            Console.WriteLine(Enum.GetName(typeof(SocialTypeEnum), 10));
        }

        public static void Demo04_GetNames()
        {
            Type type = typeof(SocialTypeEnum);
            foreach (string s in Enum.GetNames(type))
            {
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(type, Enum.Parse(type, s), "d"));
            }
        }

        public static void Demo05_GetValues()
        {
            Type type = typeof(SocialTypeEnum);
            foreach (int i in Enum.GetValues(type))
            {
                Console.WriteLine(i);
            }
        }

        public static void Enum6()
        {
            for (int i = 0; i < 5; i++)
            {
                var enumName = Enum.GetName(typeof(SocialTypeEnum), i);
                Console.WriteLine("{0}:{1}", i, enumName);
            }
            SocialTypeEnum result;
            bool result1 = Enum.TryParse("1", out result);
            bool result2 = Enum.TryParse("2", out result);
            string result3 = Enum.Format(typeof(SocialTypeEnum), "3", "X");
            string result4 = Enum.GetName(typeof(SocialTypeEnum), 2);
            string[] result5 = Enum.GetNames(typeof(SocialTypeEnum));
            Type result6 = Enum.GetUnderlyingType(typeof(SocialTypeEnum));
            Array array = Enum.GetValues(typeof(SocialTypeEnum));
            Console.WriteLine("数字{0}对应的枚举Name值:{1}", 3, Enum.GetName(typeof(SocialTypeEnum), 3));

            Type ste = typeof(SocialTypeEnum);
            object[] result7 = ste.GetField(SocialTypeEnum.Facebook.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
        }
    }
}