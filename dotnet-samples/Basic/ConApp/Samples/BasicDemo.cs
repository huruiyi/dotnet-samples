using System;
using System.Collections.Generic;
using System.Text;

namespace ConApp
{
    public class BasicDemo
    {
        public class DataType
        {
            public string TypeName { get; set; }

            public int ByteCount { get; set; }

            public object Min { get; set; }

            public object Max { get; set; }

            public Type Type { get; set; }

            public string TypeFullName { get; set; }
        }

        public static void SimpleArithmetic1()
        {
            char c1 = 'A';
            char c2 = '\u0038';
            Console.WriteLine("字符型变量c1={1},c2={0}", c1, c2);
            sbyte b1 = -12;
            byte b2 = 12;
            Console.WriteLine("字节型变量b1={0},无符号字节型变量b2={1}", b1, b2);
            short s1 = -012;         //十进制
            ushort s2 = 16;
            Console.WriteLine("短整型变量s1={0},无符号短整型变量s2={1}", s1, s2);
            int i1 = -0x48bF;      //十六进制
            uint i2 = 12;
            Console.WriteLine("整型变量i1={0},无符号整型变量i2={1}", i1, i2);
            long l1 = 0X2Dcfa6;
            ulong l2 = 0x2dcfa6L;    //整型常量加后缀L或l,说明为long型
            Console.WriteLine("长整型变量l1={0},无符号长整型变量l2={1}", l1, l2);
            float f1 = 1;
            float f2 = 22f;          //加后缀f，将浮点型常量说明为float型
            float f3 = .26f;
            Console.WriteLine("单精度浮点型变量f1={0},f2={1},f3={2}", f1, f2, f3);
            double d1 = 22D;          //加后缀D，将浮点型常量说明为double型
            double d2 = 2e2;          //double型常量
            double d3 = -2.1e12d;     //double型常量可以加后缀D或d
            decimal d4 = 22;
            decimal d5 = -2.1e12m;     //加后缀m，将浮点数型常量说明为decimal型
            Console.WriteLine("双精度浮点型变量d1={0},d2={1},d3={2}", d1, d2, d3);
            Console.WriteLine("十进制小数型变量d4={0},d5={1}", d4, d5);

            int x = 5, y = 10, z = -128;
            Console.WriteLine("{0}&{1}={2}", x, y, (x & y));
            Console.WriteLine("{0}|{1}={2}", x, y, (x | y));
            Console.WriteLine("{0}^{1}={2}", x, y, (x ^ y));
            Console.WriteLine("~{0}={1}", x, (~x));
            Console.WriteLine("{0}<<{1}={2}", z, x, (z << x));
            Console.WriteLine("{0}>>{1}={2}", z, x, (z >> x));
        }

        public static void SimpleArithmetic2()
        {
            char c1 = 'D', c2;
            sbyte sb1 = 1, sb2 = 2, sb3;
            byte b1 = 1, b2 = 2, b3;
            short s1 = 3, s2 = 4, s3;
            ushort us1 = 3, us2 = 4, us3;

            c2 = (char)(c1 + 'A');
            Console.WriteLine("char c2={0}", c2);
            sb3 = (sbyte)(sb1 - sb2);
            Console.WriteLine("sbyte  sb3={0}", sb3);
            b3 = (byte)(b1 * b2);
            Console.WriteLine("byte  b3={0}", b3);
            s3 = (short)(s1 / s2);
            Console.WriteLine("short  s3={0}", s3);
            us3 = (ushort)(us1 & us2);
            Console.WriteLine("ushort  us3={0}", us3);
        }

        public static void BoolOperation()
        {
            Console.WriteLine(true ^ false);
            Console.WriteLine(true ^ true);
            Console.WriteLine(false ^ false);
            Console.WriteLine(false ^ true);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(true & false);
            Console.WriteLine(true & true);
            Console.WriteLine(false & false);
            Console.WriteLine(false & true);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(true | false);
            Console.WriteLine(true | true);
            Console.WriteLine(false | false);
            Console.WriteLine(false | true);
            Console.WriteLine(Environment.NewLine);
        }

        public static void Yuhuofei()
        {
            int a10 = 1 ^ 0;
            int a01 = 0 ^ 1;
            int a11 = 1 ^ 1;
            Console.WriteLine(a10);
            Console.WriteLine(a01);
            Console.WriteLine(a11);

            int b10 = 1 & 0;
            int b01 = 0 & 1;
            int b11 = 1 & 1;
            Console.WriteLine(b10);
            Console.WriteLine(b01);
            Console.WriteLine(b11);

            int c10 = 1 | 0;
            int c01 = 0 | 1;
            int c11 = 1 | 1;
            Console.WriteLine(c10);
            Console.WriteLine(c01);
            Console.WriteLine(c11);
        }

        public static void Bin_Oct_Dec_Hex()
        {
            Console.WriteLine(UriPartial.Authority);
            Console.WriteLine(UriPartial.Path);
            Console.WriteLine(UriPartial.Query);
            Console.WriteLine(UriPartial.Scheme);
            Console.WriteLine(sizeof(char));
            Console.WriteLine(sizeof(byte));
            Console.WriteLine(sizeof(Byte));

            Console.WriteLine(sizeof(sbyte));
            Console.WriteLine(sizeof(SByte));

            Console.WriteLine(sizeof(short));
            Console.WriteLine(sizeof(ushort));

            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(uint));

            Console.WriteLine(sizeof(Int16));
            Console.WriteLine(sizeof(UInt16));

            Console.WriteLine(sizeof(Int32));
            Console.WriteLine(sizeof(UInt32));

            Console.WriteLine(sizeof(Int64));
            Console.WriteLine(sizeof(UInt64));

            Console.WriteLine(sizeof(decimal));
            Console.WriteLine(sizeof(Decimal));
            Console.WriteLine(sizeof(float));

            Console.WriteLine(sizeof(long));
            Console.WriteLine(sizeof(ulong));
            Console.WriteLine(sizeof(Single));

            Console.WriteLine(sizeof(UriPartial));

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{i.ToString()} {i.ToString("x")} {i.ToString("x2")} {Convert.ToString(i, 2)} {Convert.ToString(i, 8)} {Convert.ToString(i, 16)}");
            }
        }

        public static void DataTypeDemo1()
        {
            List<DataType> dataTypeList = new List<DataType>();
            dataTypeList.Add(new DataType { TypeName = "sbyte", ByteCount = sizeof(sbyte), Min = sbyte.MinValue, Max = sbyte.MaxValue, Type = typeof(sbyte) });
            dataTypeList.Add(new DataType { TypeName = "SByte", ByteCount = sizeof(SByte), Min = SByte.MinValue, Max = SByte.MaxValue, Type = typeof(SByte) });

            dataTypeList.Add(new DataType { TypeName = "byte", ByteCount = sizeof(byte), Min = byte.MinValue, Max = byte.MaxValue, Type = typeof(byte) });
            dataTypeList.Add(new DataType { TypeName = "Byte", ByteCount = sizeof(Byte), Min = Byte.MinValue, Max = Byte.MaxValue, Type = typeof(Byte) });

            dataTypeList.Add(new DataType { TypeName = "char", ByteCount = sizeof(char), Min = char.MinValue, Max = char.MaxValue, Type = typeof(char) });
            dataTypeList.Add(new DataType { TypeName = "Char", ByteCount = sizeof(Char), Min = char.MinValue, Max = Char.MaxValue, Type = typeof(Char) });

            dataTypeList.Add(new DataType { TypeName = "short", ByteCount = sizeof(short), Min = short.MinValue, Max = short.MaxValue, Type = typeof(short) });
            dataTypeList.Add(new DataType { TypeName = "ushort", ByteCount = sizeof(ushort), Min = ushort.MinValue, Max = ushort.MaxValue, Type = typeof(ushort) });
            dataTypeList.Add(new DataType { TypeName = "Int16", ByteCount = sizeof(Int16), Min = Int16.MinValue, Max = Int16.MaxValue, Type = typeof(Int16) });
            dataTypeList.Add(new DataType { TypeName = "UInt16", ByteCount = sizeof(UInt16), Min = UInt16.MinValue, Max = UInt16.MaxValue, Type = typeof(UInt16) });

            dataTypeList.Add(new DataType { TypeName = "int", ByteCount = sizeof(int), Min = int.MinValue, Max = int.MaxValue, Type = typeof(int) });
            dataTypeList.Add(new DataType { TypeName = "uint", ByteCount = sizeof(uint), Min = uint.MinValue, Max = uint.MaxValue, Type = typeof(uint) });
            dataTypeList.Add(new DataType { TypeName = "Int32", ByteCount = sizeof(Int32), Min = Int32.MinValue, Max = Int32.MaxValue, Type = typeof(Int32) });
            dataTypeList.Add(new DataType { TypeName = "UInt32", ByteCount = sizeof(UInt32), Min = UInt32.MinValue, Max = UInt32.MaxValue, Type = typeof(UInt32) });

            dataTypeList.Add(new DataType { TypeName = "long", ByteCount = sizeof(long), Min = long.MinValue, Max = long.MaxValue, Type = typeof(long) });
            dataTypeList.Add(new DataType { TypeName = "ulong", ByteCount = sizeof(ulong), Min = ulong.MinValue, Max = ulong.MaxValue, Type = typeof(ulong) });
            dataTypeList.Add(new DataType { TypeName = "Int64", ByteCount = sizeof(Int64), Min = Int64.MinValue, Max = Int64.MaxValue, Type = typeof(Int64) });
            dataTypeList.Add(new DataType { TypeName = "UInt64", ByteCount = sizeof(UInt64), Min = UInt64.MinValue, Max = UInt64.MaxValue, Type = typeof(UInt64) });

            dataTypeList.Add(new DataType { TypeName = "float", ByteCount = sizeof(float), Min = float.MinValue, Max = float.MaxValue, Type = typeof(float) });
            dataTypeList.Add(new DataType { TypeName = "double", ByteCount = sizeof(double), Min = double.MinValue, Max = double.MaxValue, Type = typeof(double) });
            dataTypeList.Add(new DataType { TypeName = "decimal", ByteCount = sizeof(decimal), Min = double.MinValue, Max = double.MaxValue, Type = typeof(decimal) });

            foreach (DataType item in dataTypeList)
            {
                item.TypeFullName = item.Type.FullName;
            }
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<table>");
            foreach (DataType item in dataTypeList)
            {
                strBuilder.Append("<tr>");
                strBuilder.Append($"<td>{item.TypeName}</td>");
                strBuilder.Append($"<td>{item.TypeFullName}</td>");
                strBuilder.Append($"<td>{item.ByteCount}</td>");
                strBuilder.Append($"<td>{item.Min}</td>");
                strBuilder.Append($"<td>{item.Max}</td>");
                strBuilder.Append("</tr>");
            }
            strBuilder.Append("</table>");
        }

        public static void PrintFormat()
        {
            Console.WriteLine("Here is the result:");
            Console.WriteLine("Processing......");
            Console.WriteLine("OK!");
            for (int i = 0; i <= 255; i++)
            {
                if (i % 4 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("{0} {1} \t", i.ToString().PadLeft(3, '0'), Convert.ToString(i, 2).PadLeft(8, '0'));
            }
        }

        public static void Forloop()
        {
            //我国古代数学家张丘建在《算经》一书中曾提出过著名的“百钱买百鸡”问题，
            //该问题叙述如下：鸡翁一，值钱五；鸡母一，值钱三；鸡雏三，值钱一；百钱
            //买百鸡，则翁、母、雏各几何？ 翻译过来，意思是公鸡一个五块钱，母鸡一个三块
            //钱，小鸡三个一块钱，现在要用一百块钱买一百只鸡，问公鸡、母鸡、小鸡各多
            //少只？题目分析如果用数学的方法解决百钱买百鸡问题，可将该问题抽象成方程式组。
            //公鸡x只，母鸡y只，小鸡z只，得到以下方程式组：
            //A：5x+3y+1/3z = 100
            //B：x+y+z = 100
            //C：0 <= x <= 100
            //D：0 <= y <= 100
            //E：0 <= z <= 100
            int i, j, k;
            Console.WriteLine("百元买百鸡的问题所有可能的解如下：");
            for (i = 0; i <= 100; i++)
            {
                for (j = 0; j <= 100; j++)
                {
                    for (k = 0; k <= 100; k++)
                    {
                        if (5 * i + 3 * j + k / 3 == 100 && k % 3 == 0 && i + j + k == 100)
                        {
                            Console.Write("公鸡{0}只，母鸡{1}只，小鸡 {2}只\n", i, j, k);
                        }
                    }
                }
            }
        }

        public static void CharacterJudge()
        {
            //3、	输入一个字符，判定它是什么类型的字符（大写字母，小写字母，数字或者其它字符）；
            Console.WriteLine(" 请输入一个字符：");
            char char_a = char.Parse(Console.ReadLine());
            if (char_a >= 'A' && char_a <= 'Z')
            {
                Console.WriteLine("大写字母!");
            }
            else if (char_a >= 'a' && char_a <= 'z')
            {
                Console.WriteLine("小写字母!");
            }
            else if (char_a >= '0' && char_a <= '9')
            {
                Console.WriteLine("数字！");
            }
            else
            {
                Console.WriteLine("其它字符！");
            }
        }

        public static void IfElse()
        {
            Console.WriteLine("请输入一个整数：");
            int int_a = int.Parse(Console.ReadLine());
            if (int_a > 0)
            {
                Console.WriteLine(int_a + 100);
            }
            else
            {
                Console.WriteLine(int_a + 500);
            }
        }
    }
}