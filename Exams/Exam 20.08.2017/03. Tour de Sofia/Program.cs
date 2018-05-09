using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Tour_de_Sofia
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[nodesCount];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < edgesCount; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int parent = int.Parse(inputs[0]);
                int child = int.Parse(inputs[1]);
                graph[parent].Add(child);
            }
            bool[] visited = new bool[nodesCount];
            int[] parents = new int[nodesCount];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            int reachableNodes = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                reachableNodes++;
                foreach (var child in graph[node])
                {
                    if (child == start)
                    {
                        int counter = 2;
                        while (parents[node] != start)
                        {
                            counter++;
                            node = parents[node];
                        }
                        Console.WriteLine(counter);
                        return;
                    }
                    if (!visited[child])
                    {
                        parents[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
            Console.WriteLine(reachableNodes);
        }
    }
}
