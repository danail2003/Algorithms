using System;
using System.Linq;

namespace SubsetSumWithRepetitions
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            bool[] sums = new bool[target + 1];
            sums[0] = true;

            for (int sum = 0; sum < sums.Length; sum++)
            {
                if (sums[sum])
                {
                    foreach (var number in numbers)
                    {
                        int newSum = number + sum;
                        if (newSum <= target)
                        {
                            sums[newSum] = true;
                        }
                    }
                }
            }

            while (target > 0)
            {
                foreach (var number in numbers)
                {
                    int previousSum = target - number;
                    if (previousSum >= 0 && sums[previousSum])
                    {
                        Console.WriteLine(number);
                        target = previousSum;
                    }
                }
            }
        }
    }
}
