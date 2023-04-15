using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPPr5
{
    internal class Task3
    {
        private object objectLock = new object();

        public void Active()
        {
            int[] arr = new int[20];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(0, 20);

            Console.WriteLine($"Original array: {ArrayToString(arr)}");
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine($"Sorted array: {ArrayToString(arr)}");

            Console.ReadKey();
        }

        private void QuickSort(int[] arr, int first, int second)
        {
            if (first < second)
            {
                int pivot = Dividing(arr, first, second);

                Thread leftThread = new Thread(() => QuickSort(arr, first, pivot - 1));
                Thread rightThread = new Thread(() => QuickSort(arr, pivot + 1, second));

                leftThread.Start();
                rightThread.Start();

                leftThread.Join();
                rightThread.Join();
            }
        }

        private int Dividing(int[] arr, int first, int second)
        {
            int pivot = arr[second];
            int i = first - 1;

            for (int j = first; j <= second - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, second);
            return i + 1;
        }

        private void Swap(int[] arr, int i, int j)
        {
            lock (objectLock)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        private string ArrayToString(int[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 == arr.Length)
                    result += arr[i];
                else
                    result += arr[i] + ", ";
            }
            return result;
        }
    }
}
