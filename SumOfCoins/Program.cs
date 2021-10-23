using System;
using System.Linq;
using System.Text;

namespace SumOfCoins
{
    class Program
    {
        static void Main()
        {
            int[] coins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            StringBuilder sb = new ();

            int counter = 0;
            int index = 0;
            coins = coins.OrderByDescending(x => x).ToArray();

            while (target > 0 && index < coins.Length)
            {
                int currentCoin = coins[index++];
                int coinsCount = target / currentCoin;

                if (coinsCount > 0)
                {
                    counter += coinsCount;
                    target -= currentCoin * coinsCount;
                    sb.AppendLine($"{coinsCount} coin(s) with value {currentCoin}");
                }
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {counter}");
                Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
