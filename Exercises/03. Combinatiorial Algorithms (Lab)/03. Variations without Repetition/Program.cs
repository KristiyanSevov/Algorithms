using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Variations_without_Repetition
{
    class Program
    {
        static string[] elements = Console.ReadLine().Split(' ');
        static int countTaken = int.Parse(Console.ReadLine());
        static bool[] visited = new bool[elements.Length];
        static string[] results = new string[countTaken];

        static void Main(string[] args)
        {
            GetVariations(0);
        }

        private static void GetVariations(int index)
        {
            if (index == countTaken)
            {
                Console.WriteLine(String.Join(" ", results));
                return;
            }
            for (int i = 0; i < elements.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    results[index] = elements[i];
                    GetVariations(index + 1);
                    visited[i] = false;
                }
            }
        }
    }
}
