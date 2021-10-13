using System;

namespace Generatin_0or1_Vectors
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] vector = new int[number];

            GenerateVectors(0, vector);
        }

        private static void GenerateVectors(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(' ', vector));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    GenerateVectors(index + 1, vector);
                }
            }
        }
    }
}
