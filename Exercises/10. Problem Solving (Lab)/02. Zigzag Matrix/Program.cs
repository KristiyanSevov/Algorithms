using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Zigzag_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];
            int[,] parentRows = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] inputs = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
                for (int j = 0; j < inputs.Length; j++)
                {
                    matrix[i, j] = inputs[j];
                }
            }
            int[,] sums = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                sums[row, 0] = matrix[row, 0];
            }
            for (int col = 1; col < cols; col++) //fill matrix col by col
            {
                for (int row = 0; row < rows; row++)
                {
                    if (col % 2 != 0)
                    {
                        int max = 0;
                        int parentRow = 0;
                        for (int r = row + 1; r < rows; r++) //values in left col below cell
                        {
                            if (sums[r, col - 1] > max)
                            {
                                max = sums[r, col - 1];
                                parentRow = r;
                            }
                        }
                        sums[row, col] = max + matrix[row, col];
                        parentRows[row, col] = parentRow; 
                    }
                    else
                    {
                        int max = 0;
                        int parentRow = 0;
                        for (int r = 0; r < row; r++) //values in left col above cell
                        {
                            if (sums[r, col - 1] > max)
                            {
                                max = sums[r, col - 1];
                                parentRow = r;
                            }
                        }
                        sums[row, col] = max + matrix[row, col];
                        parentRows[row, col] = parentRow;
                    }
                }
            }
            //recover path
            Stack<int> usedNums = new Stack<int>();
            int bestSum = 0;
            int bestIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                if (sums[row, cols - 1] > bestSum)
                {
                    bestSum = sums[row, cols - 1];
                    bestIndex = row;
                }
            }
            usedNums.Push(matrix[bestIndex, cols - 1]);
            int colIndex = cols - 2;
            int rowIndex = bestIndex;
            while (colIndex >= 0)
            {
                rowIndex = parentRows[rowIndex, colIndex + 1];
                usedNums.Push(matrix[rowIndex, colIndex]);
                colIndex--;
            }
            Console.WriteLine(String.Format("{0} = ", bestSum) + String.Join(" + ", usedNums));
        }
    }
}
