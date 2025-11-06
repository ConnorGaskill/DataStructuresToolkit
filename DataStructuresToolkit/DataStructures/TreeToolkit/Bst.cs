using System;

namespace DataStructuresToolkit.DataStructures.Trees
{
    /// <summary>
    /// Represents a Binary Search Tree (BST) data structure that stores integer values.
    /// Supports efficient insertion, search, and height computation operations.
    /// </summary>
    /// <remarks>
    /// A Binary Search Tree maintains the invariant that for any node:
    /// all values in its left subtree are less than the node's value,
    /// and all values in its right subtree are greater.
    /// Duplicate values are not inserted.
    /// </remarks>
    public class Bst
    {
        /// <summary>
        /// Represents a node within the Binary Search Tree.
        /// </summary>
        public class Node
        {
            /// <summary>
            /// The integer value stored in this node.
            /// </summary>
            public int Value;

            /// <summary>
            /// Reference to the left child node.
            /// </summary>
            public Node? Left;

            /// <summary>
            /// Reference to the right child node.
            /// </summary>
            public Node? Right;

            /// <summary>
            /// Initializes a new instance of the <see cref="Node"/> class with the specified value.
            /// </summary>
            /// <param name="value">The integer value to store in the node.</param>
            public Node(int value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Gets the root node of the Binary Search Tree.
        /// </summary>
        public Node? Root { get; private set; }

        /// <summary>
        /// Inserts a new integer value into the Binary Search Tree.
        /// If the value already exists, the tree remains unchanged.
        /// </summary>
        /// <param name="value">The integer value to insert.</param>
        /// <remarks>
        /// <para><b>Time Complexity:</b> O(h), where h is the height of the tree.</para>
        /// <para>In the average case (balanced tree), h = log n; in the worst case (skewed tree), h = n.</para>
        /// <para><b>Space Complexity:</b> O(1)</para>
        /// </remarks>
        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return;
            }

            var cur = Root;
            while (true)
            {
                if (value < cur.Value)
                {
                    if (cur.Left == null)
                    {
                        cur.Left = new Node(value);
                        return;
                    }
                    cur = cur.Left;
                }
                else if (value > cur.Value)
                {
                    if (cur.Right == null)
                    {
                        cur.Right = new Node(value);
                        return;
                    }
                    cur = cur.Right;
                }
                else
                {
                    // value already exists; no duplicates
                    return;
                }
            }
        }

        /// <summary>
        /// Determines whether the Binary Search Tree contains a specified value.
        /// </summary>
        /// <param name="value">The integer value to locate.</param>
        /// <returns><c>true</c> if the value exists in the tree; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para><b>Time Complexity:</b> O(h), where h is the height of the tree.</para>
        /// <para>In the average case (balanced tree), h = log n; in the worst case (skewed tree), h = n.</para>
        /// <para><b>Space Complexity:</b> O(1)</para>
        /// </remarks>
        public bool Contains(int value)
        {
            var cur = Root;
            while (cur != null)
            {
                if (value == cur.Value) return true;
                cur = value < cur.Value ? cur.Left : cur.Right;
            }
            return false;
        }

        /// <summary>
        /// Computes the height of a Binary Search Tree node, measured in edges.
        /// </summary>
        /// <param name="node">The root node of the subtree for which to compute height.</param>
        /// <returns>
        /// The height of the subtree rooted at <paramref name="node"/>. 
        /// Returns -1 if the node is <c>null</c>.
        /// </returns>
        /// <remarks>
        /// <para><b>Time Complexity:</b> O(n), where n is the number of nodes in the subtree.</para>
        /// <para><b>Space Complexity:</b> O(h), due to recursive call stack (h = tree height).</para>
        /// </remarks>
        public static int Height(Node? node)
        {
            if (node == null) return -1;
            int left = Height(node.Left);
            int right = Height(node.Right);
            return 1 + Math.Max(left, right);
        }
    }
}
