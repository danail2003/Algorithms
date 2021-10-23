using System;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void QuickSort(int[] numbers, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
            {
                return;
            }

            int pivot = startIdx;
            int left = startIdx + 1;
            int right = endIdx;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left += 1;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right -= 1;
                }
            }

            Swap(numbers, pivot, right);

            bool isLeftSubArraySmaller = right - 1 - startIdx < endIdx - (right + 1);

            if (isLeftSubArraySmaller)
            {
                QuickSort(numbers, startIdx, right - 1);
                QuickSort(numbers, right + 1, endIdx);
            }
            else
            {
                QuickSort(numbers, right + 1, endIdx);
                QuickSort(numbers, startIdx, right - 1);
            }
        }

        private static void Swap(int[] numbers, int left, int right)
        {
            int temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;
        }
    }
}
