﻿namespace Study5
{
    #region QuickSort
    internal class Program
    {
        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                QuickSort(arr, left, pivot - 1);
                QuickSort(arr, pivot + 1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);

            return i + 1;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 16, 5, 2, 4, 6, 1, 3, 8, 10, 21, 7 };

            QuickSort(arr, 0, arr.Length - 1);

            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
        }
    }
    #endregion

}
