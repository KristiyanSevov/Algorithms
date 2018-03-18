using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Generating_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());
            string[] results = new string[k];
            PrintCombinations(elements, results, 0, 0);
        }

        private static void PrintCombinations(string[] elements, string[] results, int resultsIndex, int beginIndex)
        {
            if (resultsIndex == results.Length)
            {
                Console.WriteLine(String.Join(" ", results));
                return;
            }
            for (int i = beginIndex; i < elements.Length; i++)
            {
                results[resultsIndex] = elements[i];
                PrintCombinations(elements, results, resultsIndex + 1, i + 1);
            }
        }
    }
}
