using System;

namespace Permutations_without_Repetitions
{
    class Program
    {
        private static string[] permutations;
        private static bool[] used;
        private static string[] elements;

        static void Main()
        {
            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permut(0);
        }

        private static void Permut(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(' ', permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Permut(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
