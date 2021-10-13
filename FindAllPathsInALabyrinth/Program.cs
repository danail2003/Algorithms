using System;
using System.Collections.Generic;

namespace FindAllPathsInALabyrinth
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, cols];
            List<char> directions = new ();

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            FindAllPaths(matrix, 0, 0, directions, '\0');
        }

        private static void FindAllPaths(char[,] matrix, int row, int col, List<char> directions, char direction)
        {
            if (IsOutside(matrix, row, col) || IsWall(matrix, row, col) || IsVisited(matrix, row, col))
            {
                return;
            }

            directions.Add(direction);

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[row, col] = 'v';

            FindAllPaths(matrix, row - 1, col, directions, 'U');
            FindAllPaths(matrix, row + 1, col, directions, 'D');
            FindAllPaths(matrix, row, col - 1, directions, 'L');
            FindAllPaths(matrix, row, col + 1, directions, 'R');

            directions.RemoveAt(directions.Count - 1);
            matrix[row, col] = '-';
        }

        private static bool IsVisited(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static bool IsWall(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(char[,] matrix, int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }
    }
}
