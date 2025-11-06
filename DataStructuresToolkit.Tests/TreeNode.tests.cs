using NUnit.Framework;
using System.Collections.Generic;
using DataStructuresToolkit.DataStructures.Trees;
using NUnit.Framework.Legacy;

namespace DataStructuresToolkit.Tests.Trees
{
    [TestFixture]
    public class BstTests
    {
        [Test]
        public void Insert_LectureSequence_ContainsAllValues_AndCorrectHeight()
        {
            // Arrange
            var bst = new Bst();
            int[] values = { 50, 30, 70, 20, 40, 60, 80 };

            // Act
            foreach (int v in values)
                bst.Insert(v);

            // Assert: Contains() works for all values
            foreach (int v in values)
                Assert.That(bst.Contains(v), Is.True);

            // Assert: should not contain missing value
            Assert.That(bst.Contains(999), Is.False);

            // Expected height = 2 edges (balanced pattern)
            int height = Bst.Height(bst.Root);
            Assert.That(height, Is.EqualTo(2));
        }

        [Test]
        public void Insert_SortedSequence_CreatesRightSkewedTree_AndCorrectHeight()
        {
            // Arrange
            var bst = new Bst();
            int[] sortedValues = { 10, 20, 30, 40, 50 };

            // Act
            foreach (int v in sortedValues)
                bst.Insert(v);

            // Assert: all values should be found
            foreach (int v in sortedValues)
                Assert.That(bst.Contains(v), Is.True);

            // Skewed tree height = n - 1
            int height = Bst.Height(bst.Root);
            Assert.That(height, Is.EqualTo(sortedValues.Length - 1));

            // Root and shape checks
            Assert.That(bst.Root!.Value, Is.EqualTo(10));
            Assert.That(bst.Root!.Right!.Right!.Value, Is.EqualTo(30));
        }

        [Test]
        public void InorderTraversal_ReturnsAscendingOrder_ForTeachingTree()
        {
            // Arrange
            var root = TreeNode.BuildTeachingTree();
            var inorder = new List<int>();

            // Act
            TreeNode.Inorder(root, inorder);

            // Assert:
            // Expected inorder (Left-Root-Right): 3, 27, 9, 38, 43
            Assert.That(new[] { 3, 27, 9, 38, 43 }, Is.EqualTo(inorder));
        }

        [Test]
        public void PreorderTraversal_ReturnsRootBeforeChildren_ForTeachingTree()
        {
            // Arrange
            var root = TreeNode.BuildTeachingTree();
            var preorder = new List<int>();

            // Act
            TreeNode.Preorder(root, preorder);

            // Assert:
            // Expected preorder (Root-Left-Right): 38, 27, 3, 9, 43
            Assert.That(new[] { 38, 27, 3, 9, 43 }, Is.EqualTo(preorder));
        }

        [Test]
        public void PostorderTraversal_ReturnsChildrenBeforeParent_ForTeachingTree()
        {
            // Arrange
            var root = TreeNode.BuildTeachingTree();
            var postorder = new List<int>();

            // Act
            TreeNode.Postorder(root, postorder);

            // Assert:
            // Expected postorder (Left-Right-Root): 3, 9, 27, 43, 38
            Assert.That(new[] { 3, 9, 27, 43, 38 }, Is.EqualTo(postorder));
        }

        [Test]
        public void TeachingTree_HeightAndDepth_Calculations_AreCorrect()
        {
            // Arrange
            var root = TreeNode.BuildTeachingTree();

            // Act
            int height = TreeNode.Height(root);
            int depthOfRoot = TreeNode.Depth(root, 38);
            int depthOfLeaf = TreeNode.Depth(root, 9);

            // Assert
            Assert.That(height, Is.EqualTo(2));
            Assert.That(depthOfRoot, Is.EqualTo(0));
            Assert.That(depthOfLeaf, Is.EqualTo(2));
        }
    }
}
