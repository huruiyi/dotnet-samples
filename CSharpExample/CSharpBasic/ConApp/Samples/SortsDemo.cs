﻿namespace ConApp
{
    public partial class Program
    {
        public static void Sort1(int[] arr)
        {
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