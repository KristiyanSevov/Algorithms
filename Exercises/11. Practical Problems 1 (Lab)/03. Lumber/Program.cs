using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Lumber
{
    class Program
    {
        static List<int>[] graph;
        static bool[] visited;
        static int[] connections;
        static int componentNumber;

        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int logCount = int.Parse(inputs[0]);
            int queries = int.Parse(inputs[1]);
            graph = new List<int>[logCount];
            for (int i = 0; i < logCount; i++)
            {
                graph[i] = new List<int>();
            }
            List<Log> logs = new List<Log>();
            for (int i = 0; i < logCount; i++)
            {
                int[] coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Log log = new Log(coords[0], coords[2], coords[3], coords[1]);
                for (int logIndex = 0; logIndex < logs.Count; logIndex++)
                {
                    if (log.IntersectsWith(logs[logIndex]))
                    {
                        graph[i].Add(logIndex);
                        graph[logIndex].Add(i);
                    }
                }
                logs.Add(log);
            }

            //get the connected components
            visited = new bool[graph.Length];
            connections = new int[graph.Length];
            componentNumber = 0;
            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    DFS(node);
                    componentNumber++;
                }
            }

            //process queries
            for (int i = 0; i < queries; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int start = int.Parse(inputs[0]) - 1; //-1 because we numbered nodes from 0
                int end = int.Parse(inputs[1]) - 1;
                Console.WriteLine(connections[start] == connections[end] ? "YES" : "NO");
            }
        }

        private static void DFS(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;
                connections[node] = componentNumber;
                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        DFS(child);
                    }
                }
            }
        }
    }

    class Log
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public Log(int x1, int x2, int y1, int y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public bool IntersectsWith(Log other)
        {
            return this.X1 <= other.X2 &&
                this.X2 >= other.X1 &&
                this.Y1 <= other.Y2 &&
                this.Y2 >= other.Y1;
        }
    }
}
