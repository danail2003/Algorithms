using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> cache;

        static void Main()
        {
            cache = new Dictionary<int, long>();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(number));
        }

        private static long Fibonacci(int number)
        {
            if (cache.ContainsKey(number))
            {
                return cache[number];
            }

            if (number <= 2)
            {
                return 1;
            }

            long result = Fibonacci(number - 1) + Fibonacci(number - 2);

            cache[number] = result;

            return result;
        }
    }
}
