using System;
using System.Linq;

namespace InsertionSort
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            InsertionSort(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int number = numbers[i];
                int index = i;

                for (int j = i; j > 0; j--)
                {
                    if (number < numbers[j - 1])
                    {
                        Swap(numbers, index, j - 1);
                        index--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void Swap(int[] numbers, int firstIndex, int secondIndex)
        {
            int temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }
    }
}
