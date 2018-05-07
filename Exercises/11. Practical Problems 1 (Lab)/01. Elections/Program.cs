using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Elections
{
    class Program
    {
        static void Main(string[] args)
        {
            int seatSum = int.Parse(Console.ReadLine());
            int partiesCount = int.Parse(Console.ReadLine());
            int[] parties = new int[partiesCount];
            for (int i = 0; i < partiesCount; i++)
            {
                parties[i] = int.Parse(Console.ReadLine());
            }
            BigInteger[] sums = new BigInteger[parties.Sum() + 1];
            sums[0] = 1;

            for (int i = 0; i < parties.Length; i++)
            {
                for (int j = sums.Length - 1; j >= 0; j--)
                {
                    if (sums[j] != 0)
                    {
                        sums[j + parties[i]] += sums[j];
                    }
                }
            }

            BigInteger count = 0;
            for (int i = seatSum; i < sums.Length; i++)
            {
                count += sums[i];
            }
            Console.WriteLine(count);
        }
    }
}
