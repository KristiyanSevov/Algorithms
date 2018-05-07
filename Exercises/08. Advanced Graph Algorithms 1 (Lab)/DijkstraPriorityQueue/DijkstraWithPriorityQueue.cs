namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();
            double[] distances = new double[graph.Count]; //nodes numbering is from 0 here
            int[] parents = new int[graph.Count];
            bool[] visited = new bool[graph.Count];
            bool[] passedQueue = new bool[graph.Count]; //probably could be done without this one
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = -1;
            }
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Double.PositiveInfinity;
            }
            sourceNode.DistanceFromStart = 0;
            distances[sourceNode.Id] = 0;
            queue.Enqueue(sourceNode);
            visited[sourceNode.Id] = true;
            while (queue.Count > 0)
            {
                Node node = queue.ExtractMin();
                if (node == destinationNode)
                {
                    break; //we can stop it once we've gotten our destination from queue (not when inserting though)
                }
                passedQueue[node.Id] = true;
                foreach (var child in graph[node])
                {
                    if (!visited[child.Key.Id])
                    {
                        visited[child.Key.Id] = true;
                        queue.Enqueue(child.Key);
                    }
                    if (child.Value + node.DistanceFromStart < distances[child.Key.Id])
                    {
                        child.Key.DistanceFromStart = child.Value + node.DistanceFromStart;
                        parents[child.Key.Id] = node.Id;
                        distances[child.Key.Id] = child.Key.DistanceFromStart;
                        if (!passedQueue[child.Key.Id])
                        {
                            queue.DecreaseKey(child.Key);
                        }
                    }
                }
            }
            List<int> results = new List<int>();
            if (distances[destinationNode.Id] == Double.PositiveInfinity)
            {
                return null;
            }
            int current = destinationNode.Id;
            while (parents[current] != -1)
            {
                results.Add(current);
                current = parents[current];
            }
            results.Add(sourceNode.Id);
            results.Reverse();
            return results;
        }
    }
}
