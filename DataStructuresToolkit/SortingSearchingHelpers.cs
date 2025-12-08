using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class SortingSearchingHelpers
    {
        // Searches

        /// <summary>
        /// Performs a binary search on a sorted integer array to find the target value.
        /// Uses a divide-and-conquer approach to repeatedly narrow the search interval.
        /// </summary>
        /// <param name="arr">A sorted array of integers to search.</param>
        /// <param name="target">The value to locate within the array.</param>
        /// <returns>
        /// The index of the target value if found; otherwise, -1.
        /// </returns>
        /// <remarks>
        /// Requirements: The array must already be sorted in ascending order.
        ///
        /// Complexity:
        /// Best Case: O(1)
        /// Average/Worst Case: O(log n)
        /// Space Complexity: O(1)
        /// </remarks>
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target)
                    return mid; // found
                else if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1; // not found
        }

        /// <summary>
        /// Performs a linear search on an integer array to find the target value.
        /// Checks each element sequentially until the value is found or the array ends.
        /// </summary>
        /// <param name="arr">The array of integers to search.</param>
        /// <param name="target">The value to locate within the array.</param>
        /// <returns>
        /// The index of the target value if found; otherwise, -1.
        /// </returns>
        /// <remarks>
        /// Complexity:
        /// Best Case: O(1)
        /// Average Case: O(n)
        /// Worst Case: O(n)
        /// Space Complexity: O(1)
        /// </remarks>
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i; // found
            }
            return -1; // not found
        }

        // Sorts

        /// <summary>
        /// Sorts an integer array in ascending order using the Bubble Sort algorithm.
        /// Compares adjacent elements and swaps them if they are in the wrong order.
        /// </summary>
        /// <param name="arr">The array of integers to sort. The sorting is performed in-place.</param>
        /// <remarks>
        /// Complexity:
        /// Best Case: O(n) — when array is already sorted.
        /// Average Case: O(n²)
        /// Worst Case: O(n²)
        ///
        /// Space Complexity: O(1)
        /// </remarks>
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an integer array in ascending order using the Merge Sort algorithm.
        /// Recursively divides the array into halves, sorts each half, and then merges them.
        /// </summary>
        /// <param name="arr">The array of integers to sort. Sorting is performed using additional arrays.</param>
        /// <remarks>
        /// Complexity:
        /// Best Case: O(n log n)
        /// Average Case: O(n log n)
        /// Worst Case: O(n log n)
        /// Space Complexity: O(n)
        /// </remarks>
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return;

            int mid = arr.Length / 2;
            int[] left = arr.Take(mid).ToArray();
            int[] right = arr.Skip(mid).ToArray();

            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right);
        }

        /// <summary>
        /// Merges two sorted subarrays (left and right)
        /// into a single sorted array (arr).
        /// </summary>
        /// <param name="arr">The destination array where merged elements are stored.</param>
        /// <param name="left">The left sorted subarray.</param>
        /// <param name="right">The right sorted subarray.</param>
        /// <remarks>
        /// Complexity:
        /// Best Case: O(n)
        /// Average Case: O(n)
        /// Worst Case: O(n)
        /// Space Complexity: O(1) — relative to the provided subarrays.
        /// </remarks>
        private static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    arr[k++] = left[i++];
                else
                    arr[k++] = right[j++];
            }

            while (i < left.Length) arr[k++] = left[i++];
            while (j < right.Length) arr[k++] = right[j++];
        }
    }
}
