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
        /// <b>Complexity:</b><br/>
        /// Best Case: O(n) — when array is already sorted.<br/>
        /// Average Case: O(n²)<br/>
        /// Worst Case: O(n²) — when array is sorted in reverse order.<br/>
        /// Space Complexity: O(1) — sorts in-place without extra memory.
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
        /// Merges two sorted subarrays (<paramref name="left"/> and <paramref name="right"/>)
        /// into a single sorted array (<paramref name="arr"/>).
        /// </summary>
        /// <param name="arr">The destination array where merged elements are stored.</param>
        /// <param name="left">The left sorted subarray.</param>
        /// <param name="right">The right sorted subarray.</param>
        /// <remarks>
        /// <b>Complexity:</b><br/>
        /// Best Case: O(n)<br/>
        /// Average Case: O(n)<br/>
        /// Worst Case: O(n)<br/>
        /// Space Complexity: O(1) — merging done in-place relative to provided arrays.
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
