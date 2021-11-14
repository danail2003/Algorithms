using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRightSum
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int[,] sums = new int[rows, cols];
            sums[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
            {
                sums[0, c] = sums[0, cols - 1] + matrix[0, c];
            }

            for (int r = 1; r < cols; r++)
            {
                sums[r, 0] = sums[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                for (int c = 1; c < matrix.GetLength(1); c++)
                {
                    int upperCell = sums[r - 1, c];
                    int leftCell = sums[r, c - 1];

                    sums[r, c] = Math.Max(upperCell, leftCell) + matrix[r, c];
                }
            }

            int row = rows - 1;
            int col = cols - 1;
            Stack<string> path = new();
            path.Push($"[{row}, {col}]");

            while (row > 0 && col > 0)
            {
                int upper = sums[row - 1, col];
                int left = sums[row, col - 1];

                if (upper > left)
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }

                path.Push($"[{row}, {col}]");
            }

            while (row > 0)
            {
                row -= 1;
                path.Push($"[{row}, {col}]");
            }

            while (col > 0)
            {
                col -= 1;
                path.Push($"[{row}, {col}]");
            }

            Console.WriteLine(string.Join(' ', path));
        }
    }
}
