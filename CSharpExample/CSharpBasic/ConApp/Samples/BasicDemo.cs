using System;

namespace ConApp
{
    public class BasicDemo
    {
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

        public static void BasicType()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("short.MinValue:" + short.MinValue);
            Console.WriteLine("short.MaxValue:" + short.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("int.MinValue:" + int.MinValue);
            Console.WriteLine("int.MaxValue:" + int.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int16.MinValue:" + Int16.MinValue);
            Console.WriteLine("Int16.MaxValue:" + Int16.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int32.MinValue:" + Int32.MinValue);
            Console.WriteLine("Int32.MaxValue:" + Int32.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int64.MinValue:" + Int64.MinValue);
            Console.WriteLine("Int64.MaxValue:" + Int64.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt16.MinValue:" + UInt16.MinValue);
            Console.WriteLine("UInt16.MaxValue:" + UInt16.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt32.MinValue:" + UInt32.MinValue);
            Console.WriteLine("UInt32.MaxValue:" + UInt32.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt64.MinValue:" + UInt64.MinValue);
            Console.WriteLine("UInt64.MaxValue:" + UInt64.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("byte.MinValue:" + byte.MinValue);
            Console.WriteLine("byte.MaxValue:" + byte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Byte.MinValue:" + Byte.MinValue);
            Console.WriteLine("Byte.MaxValue:" + Byte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("sbyte.MinValue:" + sbyte.MinValue);
            Console.WriteLine("sbyte.MaxValue:" + sbyte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("SByte.MinValue:" + SByte.MinValue);
            Console.WriteLine("SByte.MaxValue" + SByte.MaxValue);
            Console.WriteLine("**************************************************");
        }
    }
}