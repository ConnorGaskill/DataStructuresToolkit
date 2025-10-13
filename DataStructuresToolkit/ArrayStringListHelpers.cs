using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresToolkit
{
    public static class ArrayStringListHelpers
    {
        /// <summary>
        /// Inserts a value into an array at the specified index.
        /// </summary>
        /// <param name="arr">The original integer array.</param>
        /// <param name="index">The position at which to insert the value.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>A new array with the value inserted at the specified index.</returns>
        /// <remarks>
        /// Time complexity: O(n) – because all elements after the insertion index must be shifted.
        /// </remarks>
        public static int[] InsertIntoArray(int[] arr, int index, int value)
        {
            int[] newArr = new int[arr.Length + 1];

            for (int i = 0; i < index; i++)
            {
                newArr[i] = arr[i];
            }

            newArr[index] = value;

            for (int i = index; i < arr.Length; i++)
            {
                newArr[i + 1] = arr[i];
            }

            return newArr;
        }

        /// <summary>
        /// Deletes an element from an array at the specified index.
        /// </summary>
        /// <param name="arr">The original integer array.</param>
        /// <param name="index">The index of the element to delete.</param>
        /// <returns>A new array with the element removed.</returns>
        /// <remarks>
        /// Time complexity: O(n) – because all elements after the removed element must be shifted.
        /// </remarks>
        public static int[] DeleteFromArray(int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            int[] newArr = new int[arr.Length - 1];

            for (int i = 0; i < index; i++)
            {
                newArr[i] = arr[i];
            }

            for (int i = index + 1; i < arr.Length; i++)
            {
                newArr[i - 1] = arr[i];
            }

            return newArr;
        }

        /// <summary>
        /// Concatenates a list of names using string concatenation (naive approach).
        /// </summary>
        /// <param name="names">An array of names to concatenate.</param>
        /// <returns>A single comma-separated string of names.</returns>
        /// <remarks>
        /// Time complexity: O(n²) – due to repeated string copying (string immutability).
        /// </remarks>
        public static string ConcatenateNamesNaive(string[] names)
        {
            string result = "";

            foreach (string name in names)
            {
                result += name + ", ";
            }

            if (result.EndsWith(", "))
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }

        /// <summary>
        /// Concatenates a list of names using a StringBuilder (efficient approach).
        /// </summary>
        /// <param name="names">An array of names to concatenate.</param>
        /// <returns>A single comma-separated string of names.</returns>
        /// <remarks>
        /// Time complexity: O(n) – StringBuilder efficiently appends strings without reallocating.
        /// </remarks>
        public static string ConcatenateNamesBuilder(string[] names)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string name in names)
            {
                sb.Append(name).Append(", ");
            }

            if (sb.Length >= 2)
            {
                sb.Length -= 2;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Inserts a value into a list at the specified index.
        /// </summary>
        /// <param name="list">The list to modify.</param>
        /// <param name="index">The position at which to insert the value.</param>
        /// <param name="value">The value to insert.</param>
        /// <remarks>
        /// Time complexity: O(n) – inserting into the middle or beginning requires shifting elements.
        /// </remarks>
        public static void InsertIntoList(List<int> list, int index, int value)
        {
            if (index < 0 || index > list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            list.Insert(index, value);
        }
    }
}