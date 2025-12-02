using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.DataStructures.GraphToolkit
{
    /// <summary>
    /// Represents a directed graph using an adjacency list.
    /// </summary>
    public class MyGraph
    {
        private readonly Dictionary<string, List<string>> _adjacencyList;

        /// <summary>
        /// Initializes an empty graph.
        /// </summary>
        /// <remarks>
        /// Time Complexity: O(1)
        /// </remarks>
        public MyGraph()
        {
            _adjacencyList = new Dictionary<string, List<string>>();
        }

        /// <summary>
        /// Initializes a graph from a given adjacency list dictionary.
        /// </summary>
        /// <param name="adjacencyList">A dictionary representing vertices and their outgoing edges.</param>
        /// <remarks>
        /// Copies each adjacency list to preserve order and avoids modifying the input dictionary.
        /// Throws an exception if duplicate vertices are detected.
        /// Time Complexity: O(V + E), where V is the number of vertices and E is the total number of edges in the dictionary.
        /// </remarks>
        public MyGraph(Dictionary<string, List<string>> adjacencyList)
        {
            _adjacencyList = new Dictionary<string, List<string>>();
            foreach (var kvp in adjacencyList)
            {
                if (_adjacencyList.ContainsKey(kvp.Key))
                    throw new ArgumentException($"Duplicate vertex '{kvp.Key}'");

                // Copy the list to preserve exact order
                _adjacencyList[kvp.Key] = new List<string>(kvp.Value);
            }
        }

        /// <summary>
        /// Adds a new vertex to the graph if it does not already exist.
        /// </summary>
        /// <param name="vertex">The vertex identifier to add.</param>
        /// <remarks>
        /// Time Complexity: O(1) on average.
        /// </remarks>
        public void AddVertex(string vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                _adjacencyList[vertex] = new List<string>();
            }
        }

        /// <summary>
        /// Adds a directed edge from one vertex to another.
        /// </summary>
        /// <param name="from">The source vertex.</param>
        /// <param name="to">The destination vertex.</param>
        /// <remarks>
        /// If either vertex does not exist, the method does nothing.
        /// Duplicate edges are allowed in this implementation.
        /// Time Complexity: O(1) on average.
        /// </remarks>
        public void AddEdge(string from, string to)
        {
            if (!_adjacencyList.ContainsKey(from) || !_adjacencyList.ContainsKey(to))
                return;

            _adjacencyList[from].Add(to);
        }

        /// <summary>
        /// Gets the neighbors (outgoing edges) of a specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex to query.</param>
        /// <returns>
        /// A list of vertex identifiers that the given vertex has edges to.
        /// Returns an empty list if the vertex does not exist.
        /// </returns>
        /// <remarks>
        /// Time Complexity: O(1) to retrieve the list; O(k) to enumerate, where k is the number of neighbors.
        /// </remarks>
        public List<string> GetNeighbors(string vertex)
        {
            if (_adjacencyList.ContainsKey(vertex))
                return _adjacencyList[vertex];

            return new List<string>();
        }

        /// <summary>
        /// Returns the underlying adjacency list dictionary.
        /// </summary>
        /// <returns>A dictionary representing vertices and their outgoing edges.</returns>
        /// <remarks>
        /// Modifications to the returned dictionary will affect the graph.
        /// Time Complexity: O(1)
        /// </remarks>
        public Dictionary<string, List<string>> ToDictionary()
        {
            return _adjacencyList;
        }

        /// <summary>
        /// Prints the graph to the console in adjacency list format.
        /// </summary>
        /// <remarks>
        /// Each line is formatted as: vertex -> neighbor1, neighbor2, ...
        /// Time Complexity: O(V + E), where V is the number of vertices and E is the total number of edges.
        /// </remarks>
        public void Print()
        {
            foreach (var kvp in _adjacencyList)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
