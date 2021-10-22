using System;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Swap(i, i + 1, numbers);
                        isSorted = false;
                    }
                }
            }
        }

        private static void Swap(int firstIndex, int secondIndex, int[] numbers)
        {
            int temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }
    }
}
