// Week6_TreeToolkit/TreeNode.cs
namespace DataStructuresToolkit.DataStructures
{
    /// <summary>
    /// Represents a node in a binary tree. Each node contains an integer value
    /// and references to its left and right child nodes.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Gets or sets the integer value stored in this node.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the left child of this node. May be null.
        /// </summary>
        public TreeNode? Left { get; set; }

        /// <summary>
        /// Gets or sets the right child of this node. May be null.
        /// </summary>
        public TreeNode? Right { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class with the specified value.
        /// </summary>
        /// <param name="value">The integer value to store in the node.</param>
        public TreeNode(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructs and returns the example teaching tree used in lecture slides (Pages 3 & 4):
        /// <code>
        ///         38
        ///        /  \
        ///      27    43
        ///     /  \
        ///    3    9
        /// </code>
        /// This is a static utility method for creating a consistent sample tree for demonstrations.
        /// </summary>
        /// <returns>The root node of the constructed teaching tree.</returns>
        /// <remarks>Time Complexity: O(1) - fixed-size tree construction.</remarks>
        public static TreeNode BuildTeachingTree()
        {
            var root = new TreeNode(38);
            root.Left = new TreeNode(27)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(9)
            };
            root.Right = new TreeNode(43);
            return root;
        }

        /// <summary>
        /// Performs an inorder (Left-Root-Right) depth-first traversal of the binary tree
        /// starting from the given node and appends node values to the output list in traversal order.
        /// </summary>
        /// <param name="node">The current node being visited. If null, the method returns immediately.</param>
        /// <param name="output">The list to which node values are appended in inorder sequence.</param>
        /// <remarks>
        /// For a binary search tree, this produces values in sorted ascending order.
        /// Time Complexity: O(n), where n is the number of nodes in the subtree.
        /// Space Complexity: O(h) due to recursion stack, where h is the height of the tree.
        /// </remarks>
        public static void Inorder(TreeNode? node, List<int> output)
        {
            if (node == null) return;
            Inorder(node.Left, output);
            output.Add(node.Value);
            Inorder(node.Right, output);
        }

        /// <summary>
        /// Performs a preorder (Root-Left-Right) depth-first traversal of the binary tree
        /// starting from the given node and appends node values to the output list in traversal order.
        /// </summary>
        /// <param name="node">The current node being visited. If null, the method returns immediately.</param>
        /// <param name="output">The list to which node values are appended in preorder sequence.</param>
        /// <remarks>
        /// Useful for creating a copy of the tree or serializing it.
        /// Time Complexity: O(n), where n is the number of nodes in the subtree.
        /// Space Complexity: O(h) due to recursion stack, where h is the height of the tree.
        /// </remarks>
        public static void Preorder(TreeNode? node, List<int> output)
        {
            if (node == null) return;
            output.Add(node.Value);
            Preorder(node.Left, output);
            Preorder(node.Right, output);
        }

        /// <summary>
        /// Performs a postorder (Left-Right-Root) depth-first traversal of the binary tree
        /// starting from the given node and appends node values to the output list in traversal order.
        /// </summary>
        /// <param name="node">The current node being visited. If null, the method returns immediately.</param>
        /// <param name="output">The list to which node values are appended in postorder sequence.</param>
        /// <remarks>
        /// Useful for deleting a tree (process children before parent) or evaluating expression trees.
        /// Time Complexity: O(n), where n is the number of nodes in the subtree.
        /// Space Complexity: O(h) due to recursion stack, where h is the height of the tree.
        /// </remarks>
        public static void Postorder(TreeNode? node, List<int> output)
        {
            if (node == null) return;
            Postorder(node.Left, output);
            Postorder(node.Right, output);
            output.Add(node.Value);
        }

        /// <summary>
        /// Calculates the height of the subtree rooted at the given node, defined as the
        /// number of edges on the longest path from the node to a leaf.
        /// </summary>
        /// <param name="node">The root of the subtree to measure. If null, returns -1.</param>
        /// <returns>
        /// The height in edges: 
        /// - Leaf node: 0
        /// - Single-node tree: 0
        /// - Null: -1
        /// </returns>
        /// <remarks>
        /// This enables leaf nodes to correctly return height 0.
        /// Time Complexity: O(n), where n is the number of nodes in the subtree (visits each node once).
        /// Space Complexity: O(h) due to recursion stack, where h is the height of the tree.
        /// </remarks>
        public static int Height(TreeNode? node)
        {
            if (node == null) return -1; // so a leaf returns 0
            int left = Height(node.Left);
            int right = Height(node.Right);
            return 1 + Math.Max(left, right);
        }

        /// <summary>
        /// Computes the depth (number of edges from the root) of the node containing the specified target value
        /// using a depth-first search (DFS) approach. Returns the depth of the first occurrence found.
        /// </summary>
        /// <param name="root">The root node of the tree to search. If null, returns -1.</param>
        /// <param name="target">The value to locate in the tree.</param>
        /// <returns>
        /// The depth (in edges) of the target node from the root, or -1 if not found.
        /// Root depth is 0.
        /// </returns>
        /// <remarks>
        /// Uses recursive DFS and returns on the first path that finds the target.
        /// Does not guarantee finding the shallowest occurrence if duplicates exist.
        /// For teaching tree example, it correctly computes depths.
        /// Time Complexity: O(n) in worst case (may traverse entire tree).
        /// Space Complexity: O(h) due to recursion stack, where h is the height of the tree.
        /// </remarks>
        public static int Depth(TreeNode? root, int target)
        {
            int depth = 0;

            if (root == null) return -1;

            if (root.Value == target) return 0;

            int leftDepth = Depth(root.Left, target);

            if (leftDepth != -1) return leftDepth + 1;

            int rightDepth = Depth(root.Right, target);

            if (rightDepth != -1) return rightDepth + 1;

            return -1;
        }
    }
}