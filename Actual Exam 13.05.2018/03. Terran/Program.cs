using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _03.Terran
{
    class Program
    {
        static void Main(string[] args)
        {
            string chars = Console.ReadLine();
            Dictionary<char, int> counts = new Dictionary<char, int>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!counts.ContainsKey(chars[i]))
                {
                    counts.Add(chars[i], 0);
                }
                counts[chars[i]]++;
            }
            BigInteger divisor = 1;
            foreach (var num in counts.Values)
            {
                divisor *= Factorial(num);
            }
            BigInteger result = Factorial(chars.Length) / divisor;
            Console.WriteLine(result);
        }

        private static BigInteger Factorial(int n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
