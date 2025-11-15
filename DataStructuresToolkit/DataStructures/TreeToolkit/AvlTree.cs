using System;
using System.Collections.Generic;

namespace DataStructuresToolkit.DataStructures.AvlTrees
{
    /// <summary>
    /// Represents a node within an AVL tree.
    /// Each node stores an integer key, height value, and references to left and right children.
    /// </summary>
    public class AVLNode
    {
        /// <summary>The integer key stored in the node.</summary>
        public int Key;

        /// <summary>Reference to the left child node.</summary>
        public AVLNode? Left;

        /// <summary>Reference to the right child node.</summary>
        public AVLNode? Right;

        /// <summary>The height of the node for AVL balancing.</summary>
        public int Height;

        /// <summary>
        /// Initializes a new AVL tree node with a given key.
        /// </summary>
        /// <param name="key">The key to store in the node.</param>
        public AVLNode(int key)
        {
            Key = key;
            Height = 1;
        }
    }

    /// <summary>
    /// Implements an AVL (self-balancing) binary search tree.
    /// Supports insertion, search, balance checking, and manual rebalancing.
    /// </summary>
    public class AVLTree
    {
        /// <summary>
        /// Reference to the root node of the AVL tree.
        /// </summary>
        public AVLNode? Root;

        /// <summary>
        /// Computes the height of a node.
        /// </summary>
        /// <param name="node">The node whose height is being evaluated.</param>
        /// <returns>The height of the node, or 0 if null.</returns>
        /// <remarks>
        /// Time Complexity: O(n) because height is recomputed recursively.  
        /// Space Complexity: O(h) recursion depth.
        /// </remarks>
        private int Height(AVLNode? node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        /// <summary>
        /// Computes the balance factor of a node.
        /// </summary>
        /// <param name="node">The node whose balance factor is calculated.</param>
        /// <returns>Left height minus right height.</returns>
        /// <remarks>
        /// Time Complexity: O(n) due to height calls.  
        /// Space Complexity: O(h).
        /// </remarks>
        public int BalanceFactor(AVLNode? node) =>
            node == null ? 0 : Height(node.Left) - Height(node.Right);

        /// <summary>
        /// Prints a visual representation of the AVL tree including balance factors.
        /// </summary>
        /// <param name="node">The starting node to print from.</param>
        /// <param name="indent">Indentation string used for formatting.</param>
        /// <param name="isLeft">Whether this node is a left child.</param>
        /// <remarks>
        /// Time Complexity: O(n).  
        /// Space Complexity: O(h) recursion depth.
        /// </remarks>
        public void PrintTree(AVLNode? node, string indent = "", bool isLeft = true)
        {
            if (node == null) return;
            Console.WriteLine(indent + (isLeft ? "L-- " : "R-- ") +
                              node.Key + $" (BF={BalanceFactor(node)})");

            PrintTree(node.Left, indent + "   ", true);
            PrintTree(node.Right, indent + "   ", false);
        }

        /// <summary>
        /// Determines whether a key exists within the AVL tree.
        /// </summary>
        /// <param name="key">The integer value to search for.</param>
        /// <returns>True if the value is found; false otherwise.</returns>
        /// <remarks>
        /// Time Complexity: O(log n) in a balanced tree.  
        /// Space Complexity: O(h) recursion depth.
        /// </remarks>
        public bool Contains(int key)
        {
            return Contains(Root, key);
        }

        /// <summary>
        /// Recursive helper for the public <see cref="Contains(int)"/> method.
        /// </summary>
        private bool Contains(AVLNode? node, int key)
        {
            if (node == null) return false;
            if (key == node.Key) return true;
            return key < node.Key ? Contains(node.Left, key)
                                  : Contains(node.Right, key);
        }

        /// <summary>
        /// Prints the balance factors for all nodes in the tree.
        /// </summary>
        /// <param name="node">The starting node.</param>
        /// <remarks>
        /// Time Complexity: O(n).  
        /// Space Complexity: O(h).
        /// </remarks>
        public void PrintBalanceFactors(AVLNode? node)
        {
            if (node == null) return;

            Console.WriteLine($"Node {node.Key}: Balance Factor = {BalanceFactor(node)}");

            PrintBalanceFactors(node.Left);
            PrintBalanceFactors(node.Right);
        }

        /// <summary>
        /// Performs a right rotation on an AVL subtree.
        /// </summary>
        /// <param name="y">The root of the subtree to rotate.</param>
        /// <returns>The new root after rotation.</returns>
        /// <remarks>
        /// Time Complexity: O(1).  
        /// Space Complexity: O(1).
        /// </remarks>
        private AVLNode RotateRight(AVLNode y)
        {
            AVLNode x = y.Left!;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        /// <summary>
        /// Performs a left rotation on an AVL subtree.
        /// </summary>
        /// <param name="x">The root of the subtree to rotate.</param>
        /// <returns>The new root after rotation.</returns>
        /// <remarks>
        /// Time Complexity: O(1).  
        /// Space Complexity: O(1).
        /// </remarks>
        private AVLNode RotateLeft(AVLNode x)
        {
            AVLNode y = x.Right!;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        /// <summary>
        /// Inserts a new key into the AVL tree and ensures the tree remains balanced.
        /// </summary>
        /// <param name="node">The current subtree root.</param>
        /// <param name="key">The key to insert.</param>
        /// <returns>The new subtree root after insertion and rotation.</returns>
        /// <remarks>
        /// Time Complexity: O(log n) average, O(n) worst if height() is repeatedly recomputed.  
        /// Space Complexity: O(h) recursion depth.
        /// </remarks>
        public AVLNode InsertBalanced(AVLNode? node, int key)
        {
            if (node == null) return new AVLNode(key);

            if (key < node.Key)
                node.Left = InsertBalanced(node.Left, key);
            else if (key > node.Key)
                node.Right = InsertBalanced(node.Right, key);

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = BalanceFactor(node);

            if (balance > 1 && key < node.Left!.Key)
                return RotateRight(node);

            if (balance < -1 && key > node.Right!.Key)
                return RotateLeft(node);

            if (balance > 1 && key > node.Left!.Key)
            {
                node.Left = RotateLeft(node.Left!);
                return RotateRight(node);
            }

            if (balance < -1 && key < node.Right!.Key)
            {
                node.Right = RotateRight(node.Right!);
                return RotateLeft(node);
            }

            return node;
        }

        /// <summary>
        /// Rebalances the entire subtree rooted at the given node.
        /// Useful for repairing manually modified trees.
        /// </summary>
        /// <param name="node">The subtree root.</param>
        /// <returns>The new balanced subtree root.</returns>
        /// <remarks>
        /// Time Complexity: O(n × h) due to repeated height calls.  
        /// Space Complexity: O(h).
        /// </remarks>
        public AVLNode? Rebalance(AVLNode? node)
        {
            if (node == null) return null;

            node.Left = Rebalance(node.Left);
            node.Right = Rebalance(node.Right);

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = BalanceFactor(node);

            if (balance > 1)
            {
                if (BalanceFactor(node.Left) < 0)
                    node.Left = RotateLeft(node.Left!);
                return RotateRight(node);
            }

            if (balance < -1)
            {
                if (BalanceFactor(node.Right) > 0)
                    node.Right = RotateRight(node.Right!);
                return RotateLeft(node);
            }

            return node;
        }

        /// <summary>
        /// Builds a simple right-skewed AVL tree (unbalanced) for demonstration.
        /// </summary>
        /// <returns>An AVL tree where nodes lean to the right.</returns>
        /// <remarks>
        /// Time Complexity: O(1).  
        /// Space Complexity: O(1).
        /// </remarks>
        public static AVLTree BuildSkewedTree()
        {
            AVLTree tree = new AVLTree();

            tree.Root = new AVLNode(10);
            tree.Root.Right = new AVLNode(20);
            tree.Root.Right.Right = new AVLNode(30);

            tree.Root.Right.Right.Height = 1;
            tree.Root.Right.Height = 1 + Math.Max(tree.Height(tree.Root.Right.Left), tree.Height(tree.Root.Right.Right));
            tree.Root.Height = 1 + Math.Max(tree.Height(tree.Root.Left), tree.Height(tree.Root.Right));

            return tree;
        }
    }
}
