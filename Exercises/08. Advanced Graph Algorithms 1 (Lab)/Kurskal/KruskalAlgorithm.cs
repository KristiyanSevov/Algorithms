namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            int[] parents = new int[numberOfVertices]; //input vertices are numbered from 0
            List<Edge> results = new List<Edge>();
            edges.Sort();
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }
            foreach (var edge in edges)
            {
                int startRoot = FindRoot(edge.StartNode, parents);
                int endRoot = FindRoot(edge.EndNode, parents);
                if (startRoot != endRoot)
                {
                    parents[endRoot] = startRoot;
                    results.Add(edge);
                }
            }
            return results;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int beginNode = node;
            while (parent[node] != node)
            {
                node = parent[node];
            }

            //optimization to make all nodes point to the root so we don't traverse later
            int root = node;
            int current = beginNode;
            while (parent[current] != current)
            {
                int parentNode = parent[current];
                parent[current] = root;
                current = parentNode;
            }
            return root;
        }
    }
}
