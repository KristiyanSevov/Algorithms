using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Permutations_without_Repetion
{
    class Program
    {
        static string[] elements = Console.ReadLine().Split(' ');
        //static bool[] visited = new bool[elements.Length];
        //static string[] results = new string[elements.Length];

        static void Main(string[] args)
        {
            PermuteBySwaps(0);
            //PermuteRecursively(0);
        }

        private static void PermuteBySwaps(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }
            PermuteBySwaps(index + 1);
            for (int i = index + 1; i < elements.Length; i++) //index + 1 to swap with the next cell and onwards
            {
                Swap(index, i);
                PermuteBySwaps(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int x, int y)
        {
            var temp = elements[x];
            elements[x] = elements[y];
            elements[y] = temp;
        }


        //private static void PermuteRecursively(int index)
        //{
        //    if (index == elements.Length)
        //    {
        //        Console.WriteLine(String.Join(" ", results));
        //        return;
        //    }
        //    for (int i = 0; i < elements.Length; i++)
        //    {
        //        if (!visited[i])
        //        {
        //            visited[i] = true;
        //            results[index] = elements[i];
        //            PermuteRecursively(index + 1);
        //            visited[i] = false;
        //        }
        //    }
        //}
    }
}
