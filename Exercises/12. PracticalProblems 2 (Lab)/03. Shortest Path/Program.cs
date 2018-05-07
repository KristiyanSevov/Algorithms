using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Shortest_Path
{
    class Program
    {
        static char[] path;
        static char[] letters;
        static char[] result;
        static int starCount;

        static void Main(string[] args)
        {
            path = Console.ReadLine().ToCharArray();
            result = path.ToArray();
            letters = new char[] { 'L', 'R', 'S' };
            starCount = path.Count(x => x == '*');
            Console.WriteLine(Math.Pow(3, starCount));
            FindPaths(0, 0);
        }

        //not perfect but works (didn't check the algorithm)
        private static void FindPaths(int count, int border)
        {
            if (count == starCount)
            {
                Console.WriteLine(new string(result));
                return;
            }
            for (int i = border; i < path.Length; i++)
            {
                if (path[i] == '*')
                {
                    for (int j = 0; j < letters.Length; j++)
                    {
                        result[i] = letters[j];
                        FindPaths(count + 1, i + 1);
                    }
                    return;
                }
            }
        }
    }
}
