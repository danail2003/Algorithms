using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            Dictionary<int, int> sums = GetAll(numbers);

            if (!sums.ContainsKey(target))
            {
                Console.WriteLine("Sum is not existing");
                return;
            }

            while (target != 0)
            {
                int number = sums[target];
                target -= number;

                Console.WriteLine(number);
            }
        }

        private static Dictionary<int, int> GetAll(int[] numbers)
        {
            Dictionary<int, int> sums = new() { { 0, 0 } };

            foreach (var number in numbers)
            {
                int[] currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    int newSum = sum + number;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, number);
                    }
                }
            }

            return sums;
        }
    }
}
