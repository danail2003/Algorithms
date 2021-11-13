using System;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            int[,] matrix = new int[firstString.Length + 1, secondString.Length + 1];

            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                for (int c = 1; c < matrix.GetLength(1); c++)
                {
                    if (firstString[r - 1] == secondString[c - 1])
                    {
                        matrix[r, c] = matrix[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        matrix[r, c] = Math.Max(matrix[r - 1, c], matrix[r, c - 1]);
                    }
                }
            }

            Console.WriteLine(matrix[firstString.Length, secondString.Length]);
        }
    }
}
