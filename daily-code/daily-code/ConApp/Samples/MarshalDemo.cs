using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Samples
{
    public class MarshalDemo
    {
        /// <summary>
        /// Copy(IntPtr, Int64[], Int32, Int32
        /// </summary>
        public static void Marshal_01()
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
        public static void Marshal_02()
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
        public static void Marshal_03()
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
        public static void Marshal_04()
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
        public static void Marshal_05()
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
        public static void Marshal_06()
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
        public static void Marshal_07()
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
        public static void Marshal_08()
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
        public static void Marshal_09()
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
        public static void Marshal_10()
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
        public static void Marshal_11()
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
        public static void Marshal_12()
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
    }
}