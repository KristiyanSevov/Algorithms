using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            int start = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            bool[,] matrix = new bool[nums.Length + 1, max + 1];
            matrix[0, start] = true;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == true)
                    {
                        int value = nums[row];
                        if (col - value >= 0)
                        {
                            matrix[row + 1, col - value] = true;
                        }
                        if (col + value <= max)
                        {
                            matrix[row + 1, col + value] = true;
                        }
                    }
                }
            }

            int biggestVolume = matrix.GetLength(1) - 1;
            while (biggestVolume >= 0)
            {
                if (matrix[matrix.GetLength(0) - 1, biggestVolume] == true)
                {
                    break;
                }
                biggestVolume--;
            }
            Console.WriteLine(biggestVolume);
        }
    }
}
