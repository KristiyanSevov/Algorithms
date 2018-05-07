using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Stars_in_the_Cube
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,,] cube = new char[size, size, size];
            for (int row = 0; row < size; row++)
            {
                string[] inputs = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.None);
                for (int h = 0; h < size; h++)
                {
                    char[] letters = inputs[h].Split(' ').Select(x => char.Parse(x)).ToArray();
                    for (int col = 0; col < size; col++)
                    {
                        cube[row, col, h] = letters[col];
                    }
                }
            }

            Dictionary<char, int> stars = new Dictionary<char, int>();
            for (int row = 1; row < size - 1; row++) 
            {
                for (int col = 1; col < size - 1; col++)
                {
                    for (int h = 1; h < size - 1; h++) //traverse one away from the walls
                    {
                        char ch = cube[row, col, h];
                        if (cube[row, col, h - 1] == ch &&
                            cube[row, col, h + 1] == ch &&
                            cube[row - 1, col, h] == ch &&
                            cube[row + 1, col, h] == ch &&
                            cube[row, col - 1, h] == ch &&
                            cube[row, col + 1, h] == ch)
                        {
                            if (!stars.ContainsKey(ch))
                            {
                                stars.Add(ch, 0);
                            }
                            stars[ch] = stars[ch] + 1;
                        }
                    }
                }
            }
            Console.WriteLine(stars.Values.Sum());
            foreach (var kvp in stars.OrderBy(x => x.Key))
            {
                Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
