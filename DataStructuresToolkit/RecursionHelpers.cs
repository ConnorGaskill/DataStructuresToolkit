using DataStructuresToolkit.DataStructures;
using System;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Provides helper methods demonstrating various recursive techniques.
    /// </summary>
    public static class RecursionHelpers
    {
        // Mathematical

        /// <summary>
        /// Recursively computes the sum of all elements in the array starting from the given index.
        /// </summary>
        /// <param name="arr">The array of integers.</param>
        /// <param name="index">The starting index for summation.</param>
        /// <returns>The sum of elements from index to the end of the array.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        /// <remarks>
        /// Base case: When index equals the length of the array, return 0.  
        /// Recursive case: Add current element to the sum of the rest of the array.  
        /// Time complexity: O(n), Space complexity: O(n) due to recursion stack.
        /// </remarks>
        public static int SumArray(int[] arr, int index)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr), "Input array cannot be null.");

            if (index == arr.Length)
                return 0;

            return arr[index] + SumArray(arr, index + 1);
        }

        // Structural

        /// <summary>
        /// Recursively counts the number of nodes in a singly linked list.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <returns>The number of nodes in the list.</returns>
        /// <remarks>
        /// Base case: If the current node is null, return 0.  
        /// Recursive case: Return 1 + the count of nodes in the rest of the list.  
        /// Time complexity: O(n), Space complexity: O(n) due to recursion stack.
        /// </remarks>
        public static int CountList(ListNode? head)
        {
            if (head == null)
                return 0;

            return 1 + CountList(head.Next);
        }

        /// <summary>
        /// Recursively computes the total value of all nodes in a singly linked list.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <returns>The sum of all values in the list.</returns>
        /// <remarks>
        /// Base case: If the current node is null, return 0.  
        /// Recursive case: Return current node's value + the sum of the rest of the list.  
        /// Time complexity: O(n), Space complexity: O(n) due to recursion stack.
        /// </remarks>
        public static int CountListTotalValue(ListNode? head)
        {
            if (head == null)
                return 0;

            return head.Value + CountListTotalValue(head.Next);
        }

        // Problem Solving

        /// <summary>
        /// Determines if a given string is a palindrome using recursive comparison.
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <returns>True if the input is a palindrome; otherwise, false.</returns>
        /// <remarks>
        /// Base case: When left index is greater than or equal to right index, return true.  
        /// Recursive case: Compare characters at left and right; recurse inward if equal.  
        /// Time complexity: O(n), Space complexity: O(n) due to recursion stack.
        /// </remarks>
        public static bool IsPalindrome(string input)
        {
            if (input == null)
                return false;

            return IsPalindromeRecursive(input, 0, input.Length - 1);
        }

        /// <summary>
        /// Recursively checks if the substring between two indices forms a palindrome.
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <param name="left">The left index of the current comparison.</param>
        /// <param name="right">The right index of the current comparison.</param>
        /// <returns>True if the substring is a palindrome; otherwise, false.</returns>
        /// <remarks>
        /// Base case: When left >= right, the string is a palindrome.  
        /// Recursive case: If characters at left and right match, recurse inward.  
        /// Time complexity: O(n), Space complexity: O(n) due to recursion stack.
        /// </remarks>
        private static bool IsPalindromeRecursive(string input, int left, int right)
        {
            if (left >= right)
                return true;

            if (input[left] != input[right])
                return false;

            return IsPalindromeRecursive(input, left + 1, right - 1);
        }
    }
}
