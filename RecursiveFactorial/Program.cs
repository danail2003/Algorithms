using System;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(number));
        }

        private static int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
