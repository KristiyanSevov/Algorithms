using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Connected_Areas_in_a_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];
            List<Area> areas = new List<Area>();
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            while (FindStart(matrix, out int startRow, out int startCol))
            {
                Area area = new Area(startRow, startCol);
                Traverse(matrix, area, startRow, startCol);
                areas.Add(area);
            }
            Console.WriteLine("Total areas found: {0}", areas.Count);
            int counter = 1;
            foreach (var area in areas.OrderByDescending(x => x.Count).ThenBy(x => x.Row).ThenBy(x => x.Col))
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", counter, area.Row, area.Col, area.Count);
                counter++;
            }
        }

        private static void Traverse(char[,] matrix, Area area, int row, int col)
        {
            matrix[row, col] = '+'; //visited
            area.Count++;
            if (isAvailable(matrix, row, col + 1))
            {
                Traverse(matrix, area, row, col + 1);
            }
            if (isAvailable(matrix, row + 1, col))
            {
                Traverse(matrix, area, row + 1, col);
            }
            if (isAvailable(matrix, row, col - 1))
            {
                Traverse(matrix, area, row, col - 1);
            }
            if (isAvailable(matrix, row - 1, col))
            {
                Traverse(matrix, area, row - 1, col);
            }
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

        private static bool FindStart(char[,] matrix, out int startRow, out int startCol)
        {
            startRow = 0;
            startCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '-')
                    {
                        startRow = row;
                        startCol = col;
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Count { get; set; }

        public Area(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Count = 0;
        }
    }
}
