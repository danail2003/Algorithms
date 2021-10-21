using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int searchedNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, searchedNumber));
        }

        private static int BinarySearch(int[] numbers, int searchedNumber)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                int element = numbers[mid];

                if (element == searchedNumber)
                {
                    return mid;
                }

                if (searchedNumber > element)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}
