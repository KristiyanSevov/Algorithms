using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rectangle_Intersection
{
    class Program
    {
        //same solution gives 100/100 judge if written in Java
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[2001, 2001];
            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int X1 = int.Parse(inputs[0]) + 1000;
                int X2 = int.Parse(inputs[1]) + 1000;
                int Y1 = int.Parse(inputs[2]) + 1000;
                int Y2 = int.Parse(inputs[3]) + 1000;

                for (int row = Y1; row < Y2; row++)
                {
                    for (int col = X1; col < X2; col++)
                    {
                        matrix[row, col]++;
                    }
                }
            }

            int area = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 1)
                    {
                        area++;
                    }
                }
            }
            Console.WriteLine(area);
        }
    }
}
