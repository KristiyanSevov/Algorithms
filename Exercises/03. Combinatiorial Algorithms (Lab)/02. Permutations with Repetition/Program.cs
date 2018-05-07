using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Permutations_with_Repetition
{
    class Program
    {
        static string[] elements = Console.ReadLine().Split(' ');

        static void Main(string[] args)
        {
            PermuteBySwaps(0);
        }

        private static void PermuteBySwaps(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }
            HashSet<string> used = new HashSet<string>(); //already used elements for the current cell
            used.Add(elements[index]);
            PermuteBySwaps(index + 1);
            for (int i = index + 1; i < elements.Length; i++) 
            {
                if (!used.Contains(elements[i]))
                {
                    used.Add(elements[i]);
                    Swap(index, i);
                    PermuteBySwaps(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int x, int y)
        {
            var temp = elements[x];
            elements[x] = elements[y];
            elements[y] = temp;
        }
    }
}
