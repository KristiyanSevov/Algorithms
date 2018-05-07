using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private HashSet<string> visited;
    private HashSet<string> visitedForCycles;
    private LinkedList<string> results;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    ////with source removal algorithm
    //public ICollection<string> TopSort()
    //{
    //    Dictionary<string, int> predecessorCount = new Dictionary<string, int>();
    //    Queue<string> nodesWithoutPredecessor = new Queue<string>();
    //    List<string> results = new List<string>();

    //    foreach (var node in graph.Keys)
    //    {
    //        predecessorCount.Add(node, 0);
    //    }
    //    foreach (var kvp in graph)
    //    {
    //        foreach (string node in kvp.Value)
    //        {
    //            predecessorCount[node]++;
    //        }
    //    }
    //    foreach (var kvp in predecessorCount.Where(x => x.Value == 0))
    //    {
    //        nodesWithoutPredecessor.Enqueue(kvp.Key);
    //    }
    //    while (nodesWithoutPredecessor.Count > 0)
    //    {
    //        string node = nodesWithoutPredecessor.Dequeue();
    //        results.Add(node);
    //        foreach (var child in graph[node])
    //        {
    //            predecessorCount[child]--;
    //            if (predecessorCount[child] == 0)
    //            {
    //                nodesWithoutPredecessor.Enqueue(child);
    //            }
    //        }
    //    }
    //    if (results.Count != graph.Count)
    //    {
    //        throw new InvalidOperationException("There is a cycle in the graph!");
    //    }
    //    return results;
    //}

    //with DFS
    public ICollection<string> TopSort()
    {
        results = new LinkedList<string>();
        visited = new HashSet<string>();
        visitedForCycles = new HashSet<string>();
        foreach (var node in graph.Keys)
        {
            DFS(node);
        }
        return results;
    }

    private void DFS(string node)
    {
        if (visited.Contains(node)) //this order lets us not delete from visitedForCycles
        {
            return;
        }
        if (visitedForCycles.Contains(node))
        {
            throw new InvalidOperationException("There is a cycle in this graph!");
        }
        visitedForCycles.Add(node);
        foreach (var child in graph[node])
        {
            DFS(child);
        }
        visited.Add(node); //add after the recursion so that it can get to the cycle check
        results.AddFirst(node);
    }
}