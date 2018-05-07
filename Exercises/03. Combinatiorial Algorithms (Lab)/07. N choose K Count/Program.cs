using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.N_choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[,] cache = new long[n + 1, k + 1];
            Console.WriteLine(FindCount(cache, n, k));
        }

        private static long FindCount(long[,] cache, int n, int k)
        {
            if (k > n)
            {
                return 0;
            }
            if (k == 0 || k == n)
            {
                return 1;
            }
            if (cache[n, k] == 0)
            {
                cache[n, k] = FindCount(cache, n - 1, k - 1) + FindCount(cache, n - 1, k);
            }
            return cache[n, k];
        }
    }
}
