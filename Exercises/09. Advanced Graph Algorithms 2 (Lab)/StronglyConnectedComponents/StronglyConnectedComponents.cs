using System;
using System.Collections.Generic;

public class StronglyConnectedComponents
{
    private static Stack<int> nodes;
    private static bool[] visited;
    private static List<int>[] graph;
    private static List<int>[] reverseGraph;

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        nodes = new Stack<int>();
        graph = targetGraph;
        reverseGraph = new List<int>[graph.Length];
        visited = new bool[graph.Length];
        for (int node = 0; node < targetGraph.Length; node++)
        {
            DFS(node);
        }
        for (int i = 0; i < reverseGraph.Length; i++)
        {
            reverseGraph[i] = new List<int>();
        }
        for (int node = 0; node < graph.Length; node++)
        {
            foreach (var child in graph[node])
            {
                reverseGraph[child].Add(node);
            }
        }
        visited = new bool[graph.Length];
        var connectedComponents = new List<List<int>>();
        foreach (var node in nodes)
        {
            if (!visited[node])
            {
                List<int> connectedNodes = new List<int>();
                ReverseDFS(node, connectedNodes);
                connectedComponents.Add(connectedNodes);
            }
        }
        return connectedComponents;
    }

    private static void ReverseDFS(int node, List<int> connectedNodes)
    {
        if (!visited[node])
        {
            visited[node] = true;
            connectedNodes.Add(node);
            foreach (var child in reverseGraph[node])
            {
                ReverseDFS(child, connectedNodes);
            }
        }
    }

    private static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            nodes.Push(node); //stack because this ordering will eliminate one-way edges in the reverse DFS
        }
    }
}
