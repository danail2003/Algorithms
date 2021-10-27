using System;
using System.Collections.Generic;
using System.Linq;

namespace Connected_Components
{
    class Program
    {
        private static bool[] visited;
        private static List<int>[] graph;

        static void Main()
        {
            int countOfLines = int.Parse(Console.ReadLine());

            graph = new List<int>[countOfLines];
            visited = new bool[countOfLines];

            for (int i = 0; i < countOfLines; i++)
            {
                graph[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                List<int> componentList = new();
                DFS(i, componentList);

                Console.WriteLine($"Connected component: {string.Join(' ', componentList)}");
            }
        }

        private static void DFS(int node, List<int> componentList)
        {
            if (!visited[node])
            {
                visited[node] = true;
                foreach (var child in graph[node])
                {
                    DFS(child, componentList);
                }

                componentList.Add(node);
            }
        }
    }
}
