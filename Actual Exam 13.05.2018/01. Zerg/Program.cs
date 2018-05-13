using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Zerg
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int rows = int.Parse(inputs[0]);
            int cols = int.Parse(inputs[1]);
            BigInteger[,] matrix = new BigInteger[rows, cols];
            bool[,] things = new bool[rows, cols];
            string[] coords = Console.ReadLine().Split(' ');
            int endRow = int.Parse(coords[0]);
            int endCol = int.Parse(coords[1]);
            int thingsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < thingsCount; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int row = int.Parse(nums[0]);
                int col = int.Parse(nums[1]);
                things[row, col] = true;
            }
            matrix[0, 0] = 1;
            for (int col = 1; col < cols; col++)
            {
                if (things[0, col])
                {
                    break;
                }
                matrix[0, col] = 1; 
            }
            for (int row = 1; row < rows; row++)
            {
                if (things[row, 0])
                {
                    break;
                }
                matrix[row, 0] = 1;
            }
            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (!things[row, col])
                    {
                        matrix[row, col] = matrix[row - 1, col] + matrix[row, col - 1];
                    }
                }
            }
            Console.WriteLine(matrix[endRow, endCol]);
        }
    }
}
