using System;
using System.Collections.Generic;

namespace Permutation_with_Repetitions
{
    class Program
    {
        private static string[] elements;
        private static HashSet<string> permutations;

        static void Main()
        {
            elements = Console.ReadLine().Split();
            permutations = new HashSet<string>();

            Permute(0);

            foreach (var permutation in permutations)
            {
                Console.WriteLine(string.Join(' ', permutation));
            }
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                permutations.Add(string.Join(' ', elements));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            string temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
