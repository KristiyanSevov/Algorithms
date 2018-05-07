using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Blocks
{
    class Program
    {
        static List<string> results;
        static char[] chars;
        static char[] variations;
        static bool[] used;
        static HashSet<string> rotations;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            chars = new char[n];
            results = new List<string>();
            variations = new char[4];
            used = new bool[n];
            rotations = new HashSet<string>();
            int counter = 0;
            for (char i = 'A'; i <= 'Z'; i++)
            {
                chars[counter] = i;
                counter++;
                if (counter == n)
                {
                    break;
                }
            }
            GenerateVariations(0);
            Console.WriteLine("Number of blocks: {0}", results.Count);
            Console.WriteLine(String.Join(Environment.NewLine, results));
        }

        private static void GenerateVariations(int index)
        {
            if (index >= variations.Length)
            {
                if (!rotations.Contains(new string(variations)))
                {
                    results.Add(new string(variations));
                    GenerateRotations(variations);
                }
                return;
            }
            for (int i = 0; i < chars.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = chars[i];
                    GenerateVariations(index + 1);
                    used[i] = false;
                }
            }
        }

        private static void GenerateRotations(char[] variations)
        {
            rotations.Add(new string(variations));
            rotations.Add(new string(new char[] { variations[3], variations[0], variations[1], variations[2] }));
            rotations.Add(new string(new char[] { variations[2], variations[3], variations[0], variations[1] }));
            rotations.Add(new string(new char[] { variations[1], variations[2], variations[3], variations[0] }));
        }
    }
}
