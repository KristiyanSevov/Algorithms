using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Rod_Cutting
{
    class Program
    {
        static List<int> results;
        static int[] prices;
        static int[] bestPrices;

        static void Main(string[] args)
        {
            prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rodLength = int.Parse(Console.ReadLine());
            bestPrices = new int[rodLength + 1];
            results = new List<int>();

            bestPrices[0] = prices[0];
            for (int i = 1; i <= rodLength; i++)
            {
                int left = 0;
                int right = i; 
                int maxPrice = 0;
                while (left <= right)
                {
                    if (bestPrices[left] + bestPrices[right] > maxPrice)
                    {
                        maxPrice = bestPrices[left] + bestPrices[right];
                    }
                    left++;
                    right--;
                }
                bestPrices[i] = Math.Max(maxPrice, prices[i]);
            }

            FindPath(rodLength);
            Console.WriteLine(bestPrices[rodLength]);
            Console.WriteLine(String.Join(" ", results));
        }

        //there should be easier way but wanted to try this
        private static void FindPath(int rodLength)
        {
            if (bestPrices[rodLength] == prices[rodLength])
            {
                results.Add(rodLength);
            }
            else
            {
                int l = 1;
                int r = rodLength - 1;
                while (l <= r)
                {
                    if (bestPrices[l] + bestPrices[r] == bestPrices[rodLength])
                    {
                        FindPath(l);
                        FindPath(r);
                        return;
                    }
                    l++;
                    r--;
                }
            }
        }
    }
}
