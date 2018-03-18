using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Paths_in_Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];
            List<char> path = new List<char>();
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            FindPaths(matrix, path, 0, 0);
        }

        private static void FindPaths(char[,] matrix, List<char> path, int row, int col)
        {
            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(String.Join("", path));
                return;
            }
            matrix[row, col] = '+';
            if (isAvailable(matrix, row, col + 1))
            {
                path.Add('R');
                FindPaths(matrix, path, row, col + 1);
                path.RemoveAt(path.Count - 1);
            }
            if (isAvailable(matrix, row + 1, col))
            {
                path.Add('D');
                FindPaths(matrix, path, row + 1, col);
                path.RemoveAt(path.Count - 1);
            }
            if (isAvailable(matrix, row, col - 1))
            {
                path.Add('L');
                FindPaths(matrix, path, row, col - 1);
                path.RemoveAt(path.Count - 1);
            }
            if (isAvailable(matrix, row - 1, col))
            {
                path.Add('U');
                FindPaths(matrix, path, row - 1, col);
                path.RemoveAt(path.Count - 1);
            }
            matrix[row, col] = '-';
        }

        private static bool isAvailable(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && 
                col >= 0 && col < matrix.GetLength(1) && 
                matrix[row, col] != '*' && matrix[row, col] != '+')
            {
                return true;
            }
            return false;
        }
    }
}
