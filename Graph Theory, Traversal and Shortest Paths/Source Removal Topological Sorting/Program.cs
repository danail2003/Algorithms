using System;
using System.Collections.Generic;
using System.Linq;

namespace Source_Removal_Topological_Sorting
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        static void Main()
        {
            int countOfNodes = int.Parse(Console.ReadLine());

            graph = new();

            for (int i = 0; i < countOfNodes; i++)
            {
                string[] line = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
                string key = line[0].Trim();

                if (line.Length == 1)
                {
                    graph[key] = new List<string>();
                }
                else
                {
                    List<string> parts = line[1].Trim().Split(", ").ToList();

                    graph[key] = parts;
                }
            }

            dependencies = ExtractDependencies();

            List<string> sorted = TopologicalSorting();

            if (sorted.Count > 0)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }
        }

        private static List<string> TopologicalSorting()
        {
            List<string> sorted = new();

            while (dependencies.Count > 0)
            {
                KeyValuePair<string, int> nodeToRemove = dependencies.FirstOrDefault(x => x.Value == 0);

                if (nodeToRemove.Key == null)
                {
                    break;
                }

                string node = nodeToRemove.Key;
                List<string> children = graph[node];

                sorted.Add(node);

                foreach (var child in children)
                {
                    dependencies[child] -= 1;
                }

                dependencies.Remove(node);
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            dependencies = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                string node = kvp.Key;
                List<string> children = kvp.Value;

                if (!dependencies.ContainsKey(node))
                {
                    dependencies.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies.Add(child, 1);
                    }
                    else
                    {
                        dependencies[child] += 1;
                    }
                }
            }

            return dependencies;
        }
    }
}
