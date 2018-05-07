using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Longest_Common_Subsequence
{
    class Program
    {
        static int[,] matrix;

        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            matrix = new int[first.Length + 1, second.Length + 1];
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (first[row - 1] == second[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }
            //this is enough for problem as just count is expected but let's try recovery
            //Console.WriteLine(matrix[first.Length, second.Length]); 
            List<char> results = new List<char>();
            int curRow = matrix.GetLength(0) - 1;
            int curCol = matrix.GetLength(1) - 1;
            while (curRow > 0 && curCol > 0) //if one gets here, there won't be any more matches - no more chars in the string
            {
                if (first[curRow - 1] == second[curCol - 1])
                {
                    results.Add(first[curRow - 1]);
                    curRow--;
                    curCol--;
                }
                else
                {
                    if (matrix[curRow - 1, curCol] > matrix[curRow, curCol - 1])
                    {
                        curRow--;
                    }
                    else
                    {
                        curCol--;
                    }
                }
            }
            Console.WriteLine(results.Count());
        }
    }
}
