using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Eight_Queens_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 8];
            PlaceQueens(matrix, 0);
        }

        private static void PlaceQueens(int[,] matrix, int row)
        {
            if (row == 8) //we've placed all queens if we get here (one per row)
            {
                PrintSolution(matrix);
                return;
            }
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 0)
                {
                    MarkAllFields(matrix, row, col);
                    PlaceQueens(matrix, row + 1);
                    UnmarkAllFields(matrix, row, col);
                }
            }
        }
        private static void MarkAllFields(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] == 0)
                {
                    matrix[row, i] = -row - 1; //using this to separate queens from different rows
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0)
                {
                    matrix[i, col] = -row - 1;
                }
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (isInBoundsAndUnmarked(matrix, row + i, col + i))
                {
                    matrix[row + i, col + i] = -row - 1;
                }
                if (isInBoundsAndUnmarked(matrix, row - i, col - i))
                {
                    matrix[row - i, col - i] = -row - 1;
                }
                if (isInBoundsAndUnmarked(matrix, row + i, col - i))
                {
                    matrix[row + i, col - i] = -row - 1;
                }
                if (isInBoundsAndUnmarked(matrix, row - i, col + i))
                {
                    matrix[row - i, col + i] = -row - 1;
                }
            }
            matrix[row, col] = 1;
        }

        private static bool isInBoundsAndUnmarked(int[,] matrix, int row, int col)
        {
            if (row < matrix.GetLength(0) && row >= 0 && col < matrix.GetLength(1) && col >= 0 && matrix[row, col] == 0)
            {
                return true;
            }
            return false;
        }

        private static void UnmarkAllFields(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -row - 1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            matrix[row, col] = 0;
        }
        
        private static void PrintSolution(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col] == 1 ? '*' : '-');
                    sb.Append(' ');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb);
        }
    }
}
