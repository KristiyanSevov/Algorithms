using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shooting_Range
{
    class Program
    {
        static int[] targets;
        static int score;
        static HashSet<string> results;
        static bool[] visited;

        static void Main(string[] args)
        {
            targets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            score = int.Parse(Console.ReadLine());
            results = new HashSet<string>();
            visited = new bool[targets.Length];
            PermuteBySwaps(0);
            Console.WriteLine(String.Join(Environment.NewLine, results));
        }

        private static void PermuteBySwaps(int index)
        {
            int multiplier = 1;
            int sum = 0;
            for (int i = 0; i < index; i++)
            {
                sum += targets[i] * multiplier;
                multiplier++;
            }
            if (sum == score)
            {
                results.Add(String.Join(" ", targets.Take(index)));
                return;
            }
            if (index == targets.Length || sum > score)
            {
                return;
            }
            HashSet<int> used = new HashSet<int>();
            used.Add(targets[index]);
            PermuteBySwaps(index + 1);
            for (int i = index + 1; i < targets.Length; i++)
            {
                if (!used.Contains(targets[i]))
                {
                    used.Add(targets[i]);
                    Swap(index, i);
                    PermuteBySwaps(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int x, int y)
        {
            var temp = targets[x];
            targets[x] = targets[y];
            targets[y] = temp;
        }
    }
}
