namespace Dijkstra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            int[] distances = new int[graph.GetLength(0)]; //we'll do int weights here, change to double if needed
            bool[] visited = new bool[graph.GetLength(0)];
            int[] parents = Enumerable.Repeat<int>(-1, graph.Length).ToArray();
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                distances[i] = int.MaxValue;
            }
            for (int child = 0; child < graph.GetLength(0); child++) //initialize known distances
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
