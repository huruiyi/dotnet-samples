using System;

namespace ConApp.Samples
{
    public class SortDemo
    {
        public static void PrintArr(int[] arr)
        {
            foreach (var t in arr)
            {
                Console.Write(t + "\t");
            }
            Console.WriteLine();
        }

        public static void BubbleSort(int[] arr)
        {
            int tmp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }

        public static void SelectSort(int[] arr)
        {
            int tmp, pos = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[pos])
                    {
                        pos = j;
                    }
                }

                tmp = arr[i];
                arr[i] = arr[pos];
                arr[pos] = tmp;
            }
        }

        public static void InsertionSort()
        {
            Console.WriteLine("插入排序法");
            int temp = 0;
            int[] arr = { 23, 44, 66, 76, 98, 11, 3, 9, 7 };

            Console.WriteLine("排序前的数组：");
            foreach (int item in arr)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();

            var length = arr.Length;

            for (int i = 1; i < length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                    //每次排序后数组
                    PrintArr(arr);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static int sortUnit(int[] array, int low, int high)
        {
            int key = array[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while (array[high] >= key && high > low)
                    --high;
                /*比key小的放左边*/
                array[low] = array[high];
                /*从前向后搜索比key大的值，比key大的放右边*/
                while (array[low] <= key && high > low)
                    ++low;
                /*比key大的放右边*/
                array[high] = array[low];
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            array[low] = key;
            foreach (int i in array)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
            return high;
        }

        /**快速排序
*@paramarry
*@return */

        public static void sort(int[] array, int low, int high)
        {
            if (low >= high)
                return;
            /*完成一次单元排序*/
            int index = sortUnit(array, low, high);
            /*对左边单元进行排序*/
            sort(array, low, index - 1);
            /*对右边单元进行排序*/
            sort(array, index + 1, high);
        }

        public static void Sord_Test()
        {
            int[] arr = { 5, 12, 3, 19, 1, 5, 17, 16, 28, 21, 12, 3 };
            SelectSort(arr);
            PrintArr(arr);
        }
    }
}