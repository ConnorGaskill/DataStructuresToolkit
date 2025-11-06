using NUnit.Framework;
using System;
using DataStructuresToolkit.DataStructures.Trees;

namespace DataStructuresToolkit.Tests.Trees
{
    [TestFixture]
    public class BstTests
    {
        [Test]
        public void Insert_LectureSequence_ContainsAllValues()
        {
            // Arrange
            var bst = new Bst();
            int[] values = { 50, 30, 70, 20, 40, 60, 80 };

            // Act
            foreach (int v in values)
                bst.Insert(v);

            // Assert: tree should contain all inserted values
            foreach (int v in values)
                Assert.That(bst.Contains(v), Is.True, $"Tree should contain value {v}");

            // Also ensure tree does not contain a value not inserted
            Assert.That(bst.Contains(999), Is.False, "Tree should not contain value 999");

            // Height check (balanced pattern) → expected height = 2 (edges)
            int height = Bst.Height(bst.Root);
            Assert.That(height, Is.EqualTo(2), "Expected height of balanced BST is 2");
        }

        [Test]
        public void Insert_SortedSequence_CreatesSkewedTree_HeightMatchesNodeCountMinusOne()
        {
            // Arrange
            var bst = new Bst();
            int[] sortedValues = { 10, 20, 30, 40, 50 };

            // Act
            foreach (int v in sortedValues)
                bst.Insert(v);

            // Assert: contains all inserted values
            foreach (int v in sortedValues)
                Assert.That(bst.Contains(v), Is.True, $"Tree should contain value {v}");

            // Inserting sorted sequence → tree degenerates (height = n - 1)
            int height = Bst.Height(bst.Root);
            Assert.That(height, Is.EqualTo(sortedValues.Length - 1),
                $"Expected height {sortedValues.Length - 1} for a skewed (unbalanced) tree");

            // Optional: confirm tree root and skew direction
            Assert.That(bst.Root!.Value, Is.EqualTo(10));
            Assert.That(bst.Root!.Right!.Value, Is.EqualTo(20));
            Assert.That(bst.Root!.Right!.Right!.Value, Is.EqualTo(30));
        }
    }
}
