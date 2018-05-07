using System;
using System.Collections.Generic;
using System.Linq;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parents;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parents = new int[graph.Length];
        for (int i = 0; i < parents.Length; i++)
        {
            parents[i] = -1;
        }

        int maxFlow = 0;
        int start = 0;
        int end = graph.Length - 1;
        while (BFS(start, end)) //while we keep finding augmenting paths
        {
            //find smallest capacity on the path
            int smallestCapacity = int.MaxValue;
            int current = end;
            while (current != start)
            {
                int parent = parents[current];
                if (graph[parent][current] < smallestCapacity)
                {
                    smallestCapacity = graph[parent][current];
                }
                current = parent;
            }

            //update graph - subtract capacity, add flow in reverse and add to total flow
            current = end;
            while (current != start)
            {
                int parent = parents[current];
                graph[parent][current] -= smallestCapacity;
                graph[current][parent] += smallestCapacity;
                current = parent;
            }
            maxFlow += smallestCapacity;
        }
        return maxFlow;
    }

    private static bool BFS(int start, int end)
    {
        bool[] visited = new bool[graph.Length];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            for (int child = 0; child < graph.Length; child++)
            {
                if (graph[node][child] > 0 && !visited[child])
                {
                    queue.Enqueue(child);
                    visited[child] = true;
                    parents[child] = node; //that's the main point - find the augmenting path
                }
            }
        }
        return visited[end]; //whether we've found a path
    }
}
