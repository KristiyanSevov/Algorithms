using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Move_Down_or_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];
            int[,] sums = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            //fill the first row and col as base values
            sums[0, 0] = matrix[0, 0];
            for (int row = 1; row < rows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + matrix[row, 0];
            }
            for (int col = 1; col < cols; col++)
            {
                sums[0, col] = sums[0, col - 1] + matrix[0, col];
            }

            //fill the rest of sum matrix - bigger sum from left and top + cell value
            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    sums[row, col] = Math.Max(sums[row, col - 1], sums[row - 1, col]) + matrix[row, col];
                }
            }

            Stack<string> results = new Stack<string>();
            int currentRow = rows - 1;
            int currentCol = cols - 1;
            while (currentRow != 0 || currentCol != 0)
            {
                results.Push(String.Format("[{0}, {1}]", currentRow, currentCol));
                if (currentRow - 1 < 0)
                {
                    currentCol--;
                }
                else if (currentCol - 1 < 0)
                {
                    currentRow--;
                }
                else
                {
                    if (sums[currentRow - 1, currentCol] > sums[currentRow, currentCol - 1])
                    {
                        currentRow--;
                    }
                    else
                    {
                        currentCol--;
                    }
                }
            }
            results.Push(String.Format("[{0}, {1}]", 0, 0));
            Console.WriteLine(String.Join(" ", results));
        }
    }
}
