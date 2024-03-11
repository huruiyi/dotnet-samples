using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace ConApp01
{
    internal class Program
    {
        private static bool FindText(string str)
        {
            return string.CompareOrdinal(str, "7") >= 0;
        }

        public static void Demo3()
        {
            List<string> list = new List<string>
            {
                "3","4","7","9","11"
            };
            var lists1 = list.MyFindAll<string>(FindText);
            lists1.ForEach((item) =>
            {
                Console.WriteLine(item);
            });

            var lists2 = list.MyFindAll(str =>
            {
                return string.CompareOrdinal(str, "7") >= 0;
            });
            lists2.ForEach((item) =>
            {
                Console.WriteLine(item);
            });
        }

        public static int Number0;

        public static int? Number1;

        public static void Demo4()
        {
            int? ni = new int?(12);
            ni = 123456;
            Console.WriteLine(ni);
            ni = null;
            Console.WriteLine(ni);

            Console.WriteLine(Number0);
            Console.WriteLine(Number1 == null ? 123 : 456);
        }

        public static void Demo5()
        {
            Data01 data1 = new Data01 { ID = 1, Name = "UserName" };
            Data02 data2 = new Data02 { ID = 1, Name = "UserName" };
            Console.WriteLine(data1.Equals(data2));
            Console.WriteLine(data1 == data2);
        }


        public static void Demo6()
        {
            ReadOnlyCollection<TimeZoneInfo> tzCollections = TimeZoneInfo.GetSystemTimeZones();

            foreach (TimeZoneInfo item in tzCollections)
            {
                Console.WriteLine(item.DisplayName + "  " + item.DaylightName);
            }
        }


        [DllImport("msvcrt.dll", SetLastError = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void system(string command);

        public static void Demo7_Date()
        {
            system("title 纪念日");
            system(" Color 1f");
            for (int year = 2020; year <= 9999; year++)
            {
                Console.WriteLine($"----------------------------------------------------{year}----------------------------------------------------");
                for (int month = 1; month < 13; month++)
                {
                    if (month < DateTime.Now.Month && DateTime.Now.Year == year)
                    {
                        continue;
                    }
                    Console.WriteLine($"*****************************************************{month}******************************************************");

                    var daysInMonth = DateTime.DaysInMonth(year, month);
                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        DateTime dateTime = new DateTime(year, month, day);
                        DayOfWeek dayOfWeek = dateTime.DayOfWeek;
                        int week = 0;

                        switch (dayOfWeek)
                        {
                            case DayOfWeek.Monday: week = 1; break;
                            case DayOfWeek.Tuesday: week = 2; break;
                            case DayOfWeek.Wednesday: week = 3; break;
                            case DayOfWeek.Thursday: week = 4; break;
                            case DayOfWeek.Friday: week = 5; break;
                            case DayOfWeek.Saturday: week = 6; break;
                            case DayOfWeek.Sunday: week = 7; break;
                        }

                        if (day == 1)
                        {
                            for (int i = 0; i < (week - day) * 16; i++)
                            {
                                Console.Write("-");
                            }
                        }

                        Console.ForegroundColor = day == 26 ? ConsoleColor.Red : ConsoleColor.Yellow;
                        Console.Write(week + "-" + year + "-" + month.ToString().PadLeft(2, '0') + "-" + day.ToString().PadLeft(2, '0') + "\t");
                        if (dayOfWeek == DayOfWeek.Sunday)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"*****************************************************{month}******************************************************");
                    if (month == 12)
                    {
                        Console.WriteLine($"----------------------------------------------------{year}----------------------------------------------------");
                    }
                    Console.ReadKey();
                }
            }
        }



        /// <summary>
        /// Copy(IntPtr, Int64[], Int32, Int32
        /// </summary>
        private static void Marshal_01()
        {
            // Create a managed array.
            Int64[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                Int64[] managedArray2 = new Int64[managedArray.Length];
                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);
                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(IntPtr, Int32[], Int32, Int32) 
        /// </summary>
        private static void Marshal_02()
        {
            // Create a managed array.
            int[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                int[] managedArray2 = new int[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(IntPtr, Int16[], Int32, Int32) 
        /// </summary>
        private static void Marshal_03()
        {
            // Create a managed array.
            short[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                short[] managedArray2 = new short[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(IntPtr, Double[], Int32, Int32) 
        /// </summary>
        private static void Marshal_04()
        {
            // Create a managed array.
            double[] managedArray = { 0.1, 0.2, 0.3, 0.4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                double[] managedArray2 = new double[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(IntPtr, Byte[], Int32, Int32)
        /// </summary>
        private static void Marshal_05()
        {
            // Create a managed array.
            byte[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                byte[] managedArray2 = new byte[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(Int64[], Int32, IntPtr, Int32) 
        /// </summary>
        private static void Marshal_06()
        {
            // Create a managed array.
            Int64[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                Int64[] managedArray2 = new Int64[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(Int32[], Int32, IntPtr, Int32) 
        /// </summary>
        private static void Marshal_07()
        {
            // Create a managed array.
            int[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                int[] managedArray2 = new int[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(Int16[], Int32, IntPtr, Int32) 
        /// </summary>
        private static void Marshal_08()
        {
            // Create a managed array.
            short[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                short[] managedArray2 = new short[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(IntPtr, Char[], Int32, Int32) 
        /// </summary>
        private static void Marshal_09()
        {
            // Create a managed array.
            char[] managedArray = new char[1000];
            managedArray[0] = 'a';
            managedArray[1] = 'b';
            managedArray[2] = 'c';
            managedArray[3] = 'd';
            managedArray[999] = 'Z';

            // Initialize unmanaged memory to hold the array.
            // int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;  // Incorrect
            int size = Marshal.SystemDefaultCharSize * managedArray.Length;       // Correct

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                char[] managedArray2 = new char[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);
                Console.WriteLine("Here is the roundtripped array: {0} {1} {2} {3} {4}",
                    managedArray2[0], managedArray2[1], managedArray2[2], managedArray2[3],
                    managedArray2[999]);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(Double[], Int32, IntPtr, Int32) 
        /// </summary>
        private static void Marshal_10()
        {
            // Create a managed array.
            double[] managedArray = { 0.1, 0.2, 0.3, 0.4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                double[] managedArray2 = new double[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(Char[], Int32, IntPtr, Int32) 
        /// </summary>
        private static void Marshal_11()
        {
            // Create a managed array.
            char[] managedArray = new char[1000];
            managedArray[0] = 'a';
            managedArray[1] = 'b';
            managedArray[2] = 'c';
            managedArray[3] = 'd';
            managedArray[999] = 'Z';

            // Initialize unmanaged memory to hold the array.
            // int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;  // Incorrect
            int size = Marshal.SystemDefaultCharSize * managedArray.Length;       // Correct

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                char[] managedArray2 = new char[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);
                Console.WriteLine("Here is the roundtripped array: {0} {1} {2} {3} {4}",
                    managedArray2[0], managedArray2[1], managedArray2[2], managedArray2[3],
                    managedArray2[999]);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        /// <summary>
        /// Copy(Byte[], Int32, IntPtr, Int32) 
        /// </summary>
        private static void Marshal_12()
        {
            // Create a managed array.
            byte[] managedArray = { 1, 2, 3, 4 };

            // Initialize unmanaged memory to hold the array.
            int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

                // Copy the unmanaged array back to another managed array.

                byte[] managedArray2 = new byte[managedArray.Length];

                Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

                Console.WriteLine("The array was copied to unmanaged memory and back.");
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }
   
        private static void Main(string[] args)
        {
            Marshal_01();
        }
    }
}