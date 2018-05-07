using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Variations_with_Repetition
{
    class Program
    {
        static string[] elements = Console.ReadLine().Split(' ');
        static int countTaken = int.Parse(Console.ReadLine());
        static string[] results = new string[countTaken];

        static void Main(string[] args)
        {
            GetVariations(0); //same as without repetition without visited
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
                    results[index] = elements[i];
                    GetVariations(index + 1);
            }
        }
    }
}
