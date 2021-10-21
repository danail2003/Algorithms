using System;
using System.Linq;

namespace SelectionSort
{
    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SelectionSort(array);

            Console.WriteLine(string.Join(' ', array));
        }

        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int index = i;
                int minIndex = 0;
                int minValue = int.MaxValue;

                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < minValue)
                    {
                        minValue = array[j];
                        minIndex = j;
                    }
                }

                Swap(index, minIndex, array);
            }
        }

        private static void Swap(int index, int minIndex, int[] array)
        {
            int temp = array[index];
            array[index] = array[minIndex];
            array[minIndex] = temp;
        }
    }
}
