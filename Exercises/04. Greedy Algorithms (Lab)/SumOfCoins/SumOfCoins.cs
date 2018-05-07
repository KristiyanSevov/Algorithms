namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> results = new Dictionary<int, int>();
            foreach (var coin in coins.OrderByDescending(x => x))
            {
                int count = targetSum / coin;
                if (count == 0)
                {
                    continue;
                }
                results.Add(coin, count);
                targetSum -= count * coin;
                if (targetSum == 0)
                {
                    return results;
                }
            }
            throw new InvalidOperationException("sum can't be reached");
        }
    }
}