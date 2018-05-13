using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Protoss
{
    class Program
    {
        static char[,] matrix;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            matrix = new char[count, count];
            for (int row = 0; row < count; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < count; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int max = 0;
            for (int node = 0; node < count; node++)
            {
                bool[] visited = new bool[count];
                visited[node] = true;
                int connections = DFS(node, visited, 0);
                if (connections > max)
                {
                    max = connections;
                }
            }
            Console.WriteLine(max);
        }

        private static int DFS(int node, bool[] visited, int depth)
        {
            if (depth >= 2)
            {
                return 0;
            }
            int count = 0;
            List<int> children = new List<int>();
            for (int child = 0; child < matrix.GetLength(1); child++)
            {
                if (!visited[child] && matrix[node, child] == 'Y')
                {
                    visited[child] = true;
                    count++;
                    children.Add(child);
                }
            }
            foreach (var child in children)
            {
                count += DFS(child, visited, depth + 1);
            }
            return count;
        }
    }
}
