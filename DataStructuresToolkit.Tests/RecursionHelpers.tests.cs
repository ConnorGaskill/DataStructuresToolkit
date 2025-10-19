using System;
using DataStructuresToolkit;
using DataStructuresToolkit.DataStructures;
using NUnit.Framework;

namespace DataStructuresToolkit.Tests
{
    /// <summary>
    /// Contains unit tests for the RecursionHelpers class methods.
    /// </summary>
    [TestFixture]
    public class RecursionHelpersTests
    {
        /// <summary>
        /// Tests that SumArray throws an ArgumentNullException when a null array is passed.
        /// </summary>
        [Test]
        public void SumArray_ShouldThrowExceptionWhenNullValueIsPassed()
        {
            int[] nullArr = null;

            var ex = Assert.Throws<ArgumentNullException>(() =>
                RecursionHelpers.SumArray(nullArr, 0));

            Assert.That(ex.Message, Does.Contain("Input array cannot be null."));
        }

        /// <summary>
        /// Tests that SumArray returns the correct sum for a valid integer array.
        /// </summary>
        [Test]
        public void SumArray_ReturnsTheCorrectSum()
        {
            int[] arr = new int[] { 1, 2, 3 };

            Assert.That(RecursionHelpers.SumArray(arr, 0), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that CountList returns the correct count for a 3-node linked list.
        /// </summary>
        [Test]
        public void CountList_WithThreeElements_Returns3()
        {
            var nodes = new ListNode(1,
                        new ListNode(2,
                        new ListNode(3)));

            int count = RecursionHelpers.CountList(nodes);
            Assert.That(count, Is.EqualTo(3));
        }

        /// <summary>
        /// Tests that CountList returns 0 for a null (empty) linked list.
        /// </summary>
        [Test]
        public void CountList_EmptyList_Returns0()
        {
            ListNode nodes = null;

            int count = RecursionHelpers.CountList(nodes);
            Assert.That(count, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests that CountListTotalValue returns the correct total sum of node values.
        /// </summary>
        [Test]
        public void CountListTotalValue_ShouldReturnCorrectValue()
        {
            var nodes = new ListNode(1,
            new ListNode(2,
            new ListNode(3)));

            Assert.That(RecursionHelpers.CountListTotalValue(nodes), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that IsPalindrome returns true for a valid palindrome string.
        /// </summary>
        [Test]
        public void IsPalindrome_WithValidPalindrome_ReturnsTrue()
        {
            string input = "racecar";

            bool result = RecursionHelpers.IsPalindrome(input);

            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Tests that IsPalindrome returns false for a non-palindrome string.
        /// </summary>
        [Test]
        public void IsPalindrome_WithInvalidPalindrome_ReturnsFalse()
        {
            string input = "Test";

            bool result = RecursionHelpers.IsPalindrome(input);

            Assert.That(result, Is.EqualTo(false));
        }

        /// <summary>
        /// Tests that IsPalindrome returns false when passed a null string.
        /// </summary>
        [Test]
        public void IsPalindrome_WithNullInput_ReturnsFalse()
        {
            string input = null;

            bool result = RecursionHelpers.IsPalindrome(input);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
