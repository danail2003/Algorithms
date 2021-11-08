using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(RecursiveFibonacci(number));
        }

        private static int RecursiveFibonacci(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return RecursiveFibonacci(number - 1) + RecursiveFibonacci(number - 2);
        }
    }
}
