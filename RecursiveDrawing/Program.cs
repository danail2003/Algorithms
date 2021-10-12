using System;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Drawing(number);
        }

        private static void Drawing(int number)
        {
            if (number <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));
            Drawing(number - 1);
            Console.WriteLine(new string('#', number));
        }
    }
}
