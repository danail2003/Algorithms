using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        static void Main()
        {
            int countOfNodes = int.Parse(Console.ReadLine());
            int countOfEdges = int.Parse(Console.ReadLine());

            graph = ReadGraph(countOfNodes, countOfEdges);
            visited = new bool[countOfEdges];
            parents = new int[countOfEdges];

            Array.Fill(parents, -1);

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            BFS(start, end);
        }

        private static void BFS(int startNode, int end)
        {
            if (visited[startNode])
            {
                return;
            }

            Queue<int> queue = new();
            queue.Enqueue(startNode);

            visited[startNode] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                if (node == end)
                {
                    Stack<int> path = ReconstructPath(end);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(' ', path));

                    return;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parents[child] = node;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> ReconstructPath(int index)
        {
            Stack<int> path = new();

            while (index != -1)
            {
                path.Push(index);
                index = parents[index];
            }

            return path;
        }

        private static List<int>[] ReadGraph(int countOfNodes, int countOfEdges)
        {
            List<int>[] result = new List<int>[countOfNodes + 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < countOfEdges; i++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                result[line[0]].Add(line[1]);
            }

            return result;
        }
    }
}
