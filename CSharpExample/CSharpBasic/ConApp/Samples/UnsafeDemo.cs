using System;

namespace ConApp
{
    public class CPoint
    {
        public int X;
        public int Y;
    }

    public struct SPoint
    {
        public int X;
        public int Y;
    }

    public struct Xyz
    {
        public int A;
        public int B;
        public int C;
        public bool B1;
    };

    public partial class Program
    {
        public unsafe static void ArrPrintDemo()
        {
            const int al = 10;
            byte[] ints = new byte[al];
            //for (int i = 0; i < 50000; i++)
            //{
            //    new object();
            //}

            fixed (byte* ip = ints)
            {
                for (int i = 0; i < al; i++)
                {
                    Console.WriteLine(Guid.NewGuid().GetHashCode());
                    ip[i] = (byte)new Random().Next(0, 256);
                }
            }

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Array.ForEach(ints, b => Console.WriteLine(b));
        }

        public unsafe static void SquareIntPointer(int* p)
        {
            *p *= *p;
        }

        #region 变量的交换

        public static void SwapSafe(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        public static unsafe void SwapUnSafe(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwapDemo()
        {
            int i = 10, j = 20;
            SwapSafe(ref i, ref j);
            Console.WriteLine(@"Values after safe swap: i = {0}, j = {1}", i, j);

            unsafe
            {
                SwapUnSafe(&i, &j);
            }
            Console.WriteLine(@"Values after safe swap: i = {0}, j = {1}", i, j);
        }

        #endregion 变量的交换

        public static unsafe void UnsafeAddDemo1()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5 };
            int b = 3;
            int res = UnsafeAdd1(a, b);
            Console.WriteLine(res);

            unsafe
            {
                int num = 5;
                int* intp = &num;

                int result = UnsafeAdd2(num, intp);
                Console.WriteLine(result);
            }
        }

        public static int UnsafeAdd1(int[] a, int b)
        {
            unsafe
            {
                fixed (int* pa = a)//此处将锁住a，使得在fixed操作块内，a不会被CLR移动
                {
                    int sum = 0;
                    for (int i = 0; i < a.Length; i++)
                    {
                        sum += *(pa + i);
                    }
                    return sum + b;
                }
            }
        }

        public unsafe static int UnsafeAdd2(int a, int* b)//此处使用 指针，需要加入非安全代码关键字unsafe
        {
            return a + *b;
        }

        public static unsafe void UsePointerToPoint()
        {
            SPoint point;
            SPoint* p = &point;
            p->X = 100;
            p->Y = 200;
            Console.WriteLine(@"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + p->ToString());

            SPoint point2;
            SPoint* p2 = &point2;
            (*p2).X = 100;
            (*p2).Y = 200;
            Console.WriteLine(@"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + (*p2).ToString());
        }

        public static unsafe void PrintValueAndAddress()
        {
            int i;
            int* pi = &i;
            *pi = 123;

            Console.WriteLine(@"Vsalue of myInt {0}", i);
            Console.WriteLine(@"Address of myInt {0:X}", (int)&pi);
        }

        public static unsafe void UseAndPinPoint()
        {
            CPoint pt = new CPoint
            {
                X = 5,
                Y = 6
            };

            // pin pt in place so it will not be moved or GC-ed.
            fixed (int* p = &pt.X)
            {
                // Use int* variable here!
            }

            // pt is now unpinned, and ready to be GC-ed once the method completes.
            Console.WriteLine(@"Point is: {0}", pt);
        }

        public static unsafe void UseSizeOfOperator()
        {
            Console.WriteLine(@"The size of short is {0}.", sizeof(short));
            Console.WriteLine(@"The size of int is {0}.", sizeof(int));
            Console.WriteLine(@"The size of long is {0}.", sizeof(long));
            Console.WriteLine(@"The size of Point is {0}.", sizeof(Point));
        }

        public unsafe static void PointDemo()
        {
            int[] arry = null;
            arry = new int[10];
            fixed (int* pi = arry)
            {
                Console.WriteLine(@"array = 0x{0:x}", (int)pi);
            }
            int[] intArr = { 12, 13, 14, 15, 16 };
            for (int i = 0; i < intArr.Length; i++)
            {
                Console.WriteLine(@"array = 0x{0:x}", intArr[i]);
            }
            fixed (int* p = intArr)
            {
                Console.WriteLine((int)p);
            }

            CPoint pt = new CPoint();
            pt.X = 5;
            pt.Y = 6;
            // Pin pt in place:
            fixed (int* p = &pt.X)
            {
                SquareIntPointer(p);
            }

            fixed (int* p = &pt.X)
            {
                *p = 1;
            }

            double[] arr = { 0, 1.5, 2.3, 3.4, 4.0, 5.9 };
            fixed (int* p1 = &pt.X)
            {
                fixed (double* p2 = &arr[5])
                {
                    // Do something with p1 and p2.
                }
            }

            fixed (int* p1 = &pt.X)
            {
                fixed (double* p2 = &arr[5])
                {
                    // Do something with p1 and p2.
                }
            }
        }

        public unsafe static void GetPointDemo()
        {
            unsafe
            {
                int x = 10;
                int* p = &x;
                int tenAddress = (int)p;
                Console.WriteLine(@"address:{0}", tenAddress);
                Console.WriteLine(Convert.ToString(tenAddress, 2));
                Console.ReadKey();
            }
        }

        /*
          由于涉及指针类型，因此 stackalloc 要求不安全上下文。 有关更多信息，请参见 不安全代码和指针（C# 编程指南）。
          stackalloc 类似于 C 运行库中的 _alloca。
          以下代码示例计算并演示 Fibonacci 序列中的前 20 个数字。 每个数字是先前两个数字的和。
          在代码中，大小足够容纳 20 个 int 类型元素的内存块是在堆栈上分配的，而不是在堆上分配的。
          该块的地址存储在 fib 指针中。 此内存不受垃圾回收的制约，因此不必将其钉住（通过使用 fixed）。
          内存块的生存期受限于定义它的方法的生存期。 不能在方法返回之前释放内存。
      */

        public static unsafe void UnsafeStackAlloc1()
        {
            int* block = stackalloc int[100];

            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
            {
                p[k] = (char)k;
            }
        }

        public static unsafe void UnsafeStackAlloc2()
        {
            const int arraySize = 20;
            int* fib = stackalloc int[arraySize];
            int* p = fib;
            // The sequence begins with 1, 1.
            *p++ = *p++ = 1;
            for (int i = 2; i < arraySize; ++i, ++p)
            {
                // Sum the previous two numbers.
                *p = p[-1] + p[-2];
            }
            for (int i = 0; i < arraySize; ++i)
            {
                Console.WriteLine(fib[i]);
            }
        }

        public static void Demo1()
        {
            unsafe
            {
                int[] array = { 10, 20, 30, 40, 50 };
                fixed (int* ptr = array)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        //Console.WriteLine("array = 0x{0:x}", (int)(ptr+i));
                        Console.WriteLine(@"{0}--{1}--{2}--0x{3:x}", i, *(ptr + i), array[i], (int)(ptr + i));
                        //Console.WriteLine("Content of the {0}th element of the array: Using pointer: {1}, Using array index: {2}", i, *(ptr + i), array[i]);
                    }
                }
            }
        }

        public static void Demo2()
        {
            var s = "Hello";                                     // stores given string into HashSet where all string are strored in .NET
                                                                 // due string immutability

            unsafe                                                   // allows write to read-only memory
            {
                fixed (char* c = s)                             // get pointer to string originally stored in read only memory
                    for (int i = 0; i < s.Length; i++)
                        c[i] = 'a';                                    // change data in memory allocated for original "Hello"
            }
            Console.WriteLine(@"Hello");                  // .NET looks on address in memory where it expect
                                                          // data for string "Hello" but it was just changed
                                                          // Displays: "aaaaa"
        }

        public static void Demo3()
        {
            unsafe
            {
                int[] a = { 1, 2, 3 };
                fixed (int* b = a)
                {
                    Console.WriteLine(b[4]);
                }
            }
        }

        public static void Demo4()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            unsafe
            {
                fixed (int* ptr = array)
                {
                    for (int i = 0; i <= array.Length; i++)
                    {
                        *(ptr + i) = 0;
                    }
                }
            }
        }

        //静态变量存储在堆上，查看指针时需用fixed固定
        public static int M_SZ = 100;

        //普通数据成员，也是放在堆上了，查看指针时需用fixed固定
        public int MNData = 100;

        //等价于C/C++的 #define 语句，不分配内存
        public const int PI = 31415;

        //http://blog.csdn.net/dijkstar/article/details/9204707
        public static unsafe void Demo5()
        {
            //简单的结构变量放在栈上，无需fixed
            Xyz stData = new Xyz { A = 100 };
            Console.WriteLine(@"结构变量= 0x{0:x}", (int)&stData);

            //数组变量的声明放在了栈上，数据放在了堆上，需用fixed固定
            int[] arry = null;
            arry = new int[10];
            fixed (int* p = arry)
            {
                Console.WriteLine(@"array = 0x{0:x}", (int)p);
            }

            //这些放在栈上的变量，可以直接使用指针指向
            //从打印的指针的数据看，int是4字节的，double是8字节的
            int y = 10;
            int z = 100;
            double f = 0.90;
            Console.WriteLine(@"本地变量y = 0x{0:X}, z = 0x{1:X}", (int)&y, (int)&z);
            Console.WriteLine(@"本地变量f = 0x{0:X}", (int)&f);

            //下面失败
            //fixed (int* p = &P.PI)
            //{
            //}

            //放在堆里面的数据的地址，就必须用fixed语句！
            string ss = "Helo";
            fixed (char* p = ss)
            {
                Console.WriteLine(@"字符串地址= 0x{0:x}", (int)p);
            }

            Program s = new Program();
            //这个是类对象，放在堆里面
            fixed (int* p = &s.MNData)
            {
                Console.WriteLine(@"普通类成员变量 = 0x{0:X}", (int)p);
            }

            //静态成员变量在堆上
            fixed (int* p = &M_SZ)
            {
                Console.WriteLine(@"静态成员变量 = 0x{0:X}", (int)p);
            }

            //下面是每种类型的占用字节个数
            Console.WriteLine(@"下面是每种类型的占用字节个数");
            Console.WriteLine(@"sizeof(void *) = {0}", sizeof(void*));
            Console.WriteLine(@"sizeof(int) = {0}, * = {1}", sizeof(int), sizeof(int*));//4
            Console.WriteLine(@"sizeof(long) = {0}, * = {1}", sizeof(long), sizeof(long*));//8
            Console.WriteLine(@"sizeof(byte) = {0}, * = {1}", sizeof(byte), sizeof(byte*));//1
            Console.WriteLine(@"sizeof(bool) = {0}, * = {1}", sizeof(bool), sizeof(bool*));//1
            Console.WriteLine(@"sizeof(float) = {0}, * = {1}", sizeof(float), sizeof(float*));//4
            Console.WriteLine(@"sizeof(double) = {0}, * = {1}", sizeof(double), sizeof(double*));//8
            Console.WriteLine(@"sizeof(decimal) = {0}, * = {1}", sizeof(decimal), sizeof(decimal*));//16
            Console.WriteLine(@"sizeof(char) = {0}, * = {1}", sizeof(char), sizeof(char*));//
            Console.WriteLine(@"sizeof(XYZ) = {0}, * = {1}", sizeof(Xyz), sizeof(Xyz*));//
            //Console.WriteLine("sizeof(object) = {0}, * = {1}", sizeof(object), sizeof(object*));//16
            //Console.WriteLine("sizeof(C) = {0}, * = {1}", sizeof(C), sizeof(C*));//16
        }
    }
}