using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shortest_Path_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputs[col];
                }
            }
            //definitely not optimal (sparse graph) but good enough for this problem
            int[,] graph = new int[rows * cols, rows * cols]; 
            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row - 1 >= 0)
                    {
                        graph[counter, counter - cols] = matrix[row - 1, col];
                    }
                    if (row + 1 < rows)
                    {
                        graph[counter, counter + cols] = matrix[row + 1, col];
                    }
                    if (col - 1 >= 0)
                    {
                        graph[counter, counter - 1] = matrix[row, col - 1];
                    }
                    if (col + 1 < cols)
                    {
                        graph[counter, counter + 1] = matrix[row, col + 1];
                    }
                    counter++;
                }
            }
            List<int> path = DijkstraAlgorithm(graph, 0, rows * cols - 1);
            List<int> result = new List<int>();
            foreach (var node in path)
            {
                int row = node / cols;
                int col = node - row * cols;
                result.Add(matrix[row, col]);
            }
            Console.WriteLine("Length: {0}", result.Sum());
            Console.WriteLine("Path: {0}", string.Join(" ", result));
        }

        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            int[] distances = new int[graph.GetLength(0)]; 
            bool[] visited = new bool[graph.GetLength(0)];
            int[] parents = Enumerable.Repeat<int>(-1, graph.Length).ToArray();
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                distances[i] = int.MaxValue;
            }
            for (int child = 0; child < graph.GetLength(0); child++) 
            {
                if (graph[sourceNode, child] > 0)
                {
                    distances[child] = graph[sourceNode, child];
                }
            }
            distances[sourceNode] = 0;

            while (true)
            {
                //find nearest unvisited node
                int minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < graph.GetLength(0); node++)
                {
                    if (!visited[node] && distances[node] < minDistance)
                    {
                        minDistance = distances[node];
                        minNode = node;
                    }
                }
                if (minDistance == int.MaxValue)
                {
                    break; //no more nodes to be reached
                }
                visited[minNode] = true;

                //improve distances from source
                for (int child = 0; child < graph.GetLength(0); child++)
                {
                    if (graph[minNode, child] > 0)
                    {
                        int distance = distances[minNode] + graph[minNode, child];
                        if (distance < distances[child])
                        {
                            distances[child] = distance;
                            parents[child] = minNode;
                        }
                    }
                }
            }

            //reconstruct path
            if (distances[destinationNode] == int.MaxValue)
            {
                return null;
            }
            List<int> results = new List<int>();
            int current = destinationNode;
            while (current != -1)
            {
                results.Add(current);
                current = parents[current];
            }
            results.Add(sourceNode);
            results.Reverse();
            return results;
        }
    }
}
