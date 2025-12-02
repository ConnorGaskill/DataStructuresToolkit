using System;
using System.Collections.Generic;

namespace DataStructuresToolkit.DataStructures.GraphToolkit
{
    public static class GraphHelpers
    {
        /// <summary>
        /// Recursively performs a depth-first search (DFS) starting from a given vertex.
        /// </summary>
        /// <param name="vertex">The current vertex to visit.</param>
        /// <param name="graph">The graph to traverse.</param>
        /// <param name="visited">A set of already visited vertices.</param>
        /// <remarks>
        /// Prints the visited vertices to the console in DFS order.
        /// Time Complexity: O(V + E), where V is the number of vertices and E is the number of edges.
        /// </remarks>
        private static void DFS(string vertex, MyGraph graph, HashSet<string> visited)
        {
            if (visited.Contains(vertex))
                return;

            visited.Add(vertex);

            Console.WriteLine(vertex);

            var neighbors = graph.GetNeighbors(vertex);
            if (neighbors == null)
                throw new ArgumentException($"Vertex '{vertex}' not found in graph.");

            foreach (var neighbor in neighbors)
            {
                DFS(neighbor, graph, visited);
            }
        }

        /// <summary>
        /// Performs a depth-first search (DFS) traversal of the graph starting from the specified vertex.
        /// </summary>
        /// <param name="start">The starting vertex for the traversal.</param>
        /// <param name="graph">The graph to traverse.</param>
        /// <remarks>
        /// Wrapper for calling DFS without passing a HashSet for visited nodes required for recursive logic
        /// Adds a null check
        /// </remarks>
        public static void DFS(string start, MyGraph graph)
        {
            ArgumentNullException.ThrowIfNull(graph);

            DFS(start, graph, new HashSet<string>());
        }

        /// <summary>
        /// Performs a breadth-first search (BFS) traversal of the graph starting from the specified vertex.
        /// </summary>
        /// <param name="start">The starting vertex for the traversal.</param>
        /// <param name="graph">The graph to traverse.</param>
        /// <remarks>
        /// Prints the visited vertices to the console in BFS order.
        /// Uses a queue to traverse neighbors level by level.
        /// Time Complexity: O(V + E), where V is the number of vertices and E is the number of edges.
        /// </remarks>
        public static void BFS(string start, MyGraph graph)
        {
            ArgumentNullException.ThrowIfNull(graph);

            if (!graph.ToDictionary().ContainsKey(start))
                throw new ArgumentException($"Start vertex '{start}' not found in graph.");

            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex);

                var neighbors = graph.GetNeighbors(vertex) ?? throw new ArgumentException($"Vertex '{vertex}' not found in graph.");

                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
