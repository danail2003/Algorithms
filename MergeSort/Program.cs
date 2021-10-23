using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sortedNumbers = MergeSort(numbers);

            Console.WriteLine(string.Join(' ', sortedNumbers));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers;
            }

            int[] left = numbers.Take(numbers.Length / 2).ToArray();
            int[] right = numbers.Skip(numbers.Length / 2).ToArray();

            return MergeArrays(MergeSort(left), MergeSort(right));
        }

        private static int[] MergeArrays(int[] left, int[] right)
        {
            int[] mergedArray = new int[left.Length + right.Length];
            int mergedIdx = 0;
            int leftIdx = 0;
            int rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    mergedArray[mergedIdx++] = left[leftIdx++];
                }
                else
                {
                    mergedArray[mergedIdx++] = right[rightIdx++];
                }
            }

            while (leftIdx < left.Length)
            {
                mergedArray[mergedIdx++] = left[leftIdx++];
            }

            while (rightIdx < right.Length)
            {
                mergedArray[mergedIdx++] = right[rightIdx++];
            }

            return mergedArray;
        }
    }
}
