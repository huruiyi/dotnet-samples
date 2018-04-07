namespace ConApp
{
    public class SortsDemo
    {
        /* 时间复杂度 和 空间复杂度
         *
         * 时间复杂度 计算 算法 所需的工作量
         *
         * 空间复杂度 计算 算法 所需的内存
         *
         * 用大写 O 来表示
         *
         * 最好情况（最理想状态）
         *
         * 最坏情况
         *
         *
         * PetShop
         *
         * Dinner
         *
         * Music Store
         *
         *
         * NLayer  DDD
         *
         */

        /// <summary>
        /// 首先 从第二数开始取（默认 认为 第一个数 已经配排序了）
        /// 第二个数 和第一个数 进行比较
        /// 如果比第一个数大 就不动，如果 第一个数小 就换位置，
        /// 第三个数 要和前面的所有数 进行比较 重复上面过程
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] InsertSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int insertValue = array[i];
                int insertIndex = i - 1;

                while (insertIndex >= 0 && insertValue < array[insertIndex])
                {
                    array[insertIndex + 1] = array[insertIndex];
                    insertIndex--;
                }
                array[insertIndex + 1] = insertValue;
            }
            return array;
        }

        /// <summary>
        /// O(n^2)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] BubbleSort(int[] array)
        {
            int length = array.Length;
            int temp;

            //N-1次循环
            for (int i = 0; i < length - 1; i++)
            {
                //从数组下标0出来时遍历 length-i-1 是排除已经排序好的数
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        /// <summary>
        /// 选择排序
        /// 最先在未排序的序列中找到最小元素 把它放到起始位置，
        /// 然后再在剩余未排序的元素中找到最小元素
        /// 再放到已排序的序列末尾，以此类推
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] SelectSort(int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                int minValue = array[i];//最小数
                int minIndex = i;//最小数的下标

                //这里只需要找到这一波最小值，并记录它的小标
                for (int j = i + 1; j < array.Length; j++)
                {
                    //如果我们认为它是最小的
                    if (minValue > array[j])
                    {
                        minValue = array[j];
                        minIndex = j;
                    }
                }
                //把最小值和第一个位置的数交换
                temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }

            return array;
        }

        public static void Sort1(int[] arr)
        {
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = i + 1; j < arr.Length; j++)
            //    {
            //        if (arr[i] < arr[j])
            //        {
            //            int temp = arr[i];
            //            arr[i] = arr[j];
            //            arr[j] = temp;
            //        }
            //    }
            //}

            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}