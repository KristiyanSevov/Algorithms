using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int?[] parents;
    private static int[] depths;
    private static int[] lowpoints;
    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[targetGraph.Length];
        parents = new int?[visited.Length];
        depths = new int[visited.Length];
        lowpoints = new int[visited.Length];
        articulationPoints = new List<int>();

        FindArticulationPoints(0, 0);
        return articulationPoints;
    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoints[node] = depth;
        int childCount = 0; //we'll need that to see if the starting node is articulation point
        bool isArticulation = false;
        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                parents[child] = node;
                FindArticulationPoints(child, depth + 1);
                childCount++;
                if (lowpoints[child] >= depths[node]) //we found a child from which we can't reach "behind" our node 
                {                                     //this section will get cut off once node is removed
                    isArticulation = true; // >= because if we can reach our node, child is still cut off when node is removed
                }
                lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
            }
            //we don't want to use our parent-node edge in reverse because the idea is to find path to behind from forward nodes
            //which will be preserved if we remove our node - the edge to the parent though will disappear, so we don't count it
            else if (child != parents[node])
            {
                //depths[child] because that's where path ends, i.e. completes the cycle
                //lowpoint could give smaller value (further back along other paths) and "create" non-existent edge
                lowpoints[node] = Math.Min(lowpoints[node], depths[child]);
            }
        }
        //more than one child would mean we couldn't DFS the whole graph from the first child => remove node, separate that part
        if ((parents[node] != null && isArticulation) ||
            (parents[node] == null && childCount > 1)) 
        {
            articulationPoints.Add(node);
        }
    }
}
