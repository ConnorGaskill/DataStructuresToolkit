using System;
using System.Collections.Generic;

namespace DataStructuresToolkit.DataStructures.StackQueues
{
    /// <summary>
    /// A min-heap based priority queue for integers.
    /// Provides fast insertion and retrieval of the smallest element.
    /// </summary>
    public class PriorityQueue
    {
        /// <summary>
        /// Internal list storing heap elements.
        /// Represents a complete binary tree in array form.
        /// </summary>
        private List<int> heap = new List<int>();

        /// <summary>
        /// Inserts a new integer into the priority queue.
        /// </summary>
        /// <param name="val">The value to insert.</param>
        /// <remarks>
        /// Time Complexity: O(log n) due to bubble-up.
        /// Space Complexity: O(1) auxiliary, O(n) total including stored values.
        /// </remarks>
        public void Enqueue(int val)
        {
            heap.Add(val);
            BubbleUp(heap.Count - 1);
        }

        /// <summary>
        /// Removes and returns the smallest element in the priority queue.
        /// </summary>
        /// <returns>The minimum integer stored in the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when attempting to dequeue from an empty queue.</exception>
        /// <remarks>
        /// Time Complexity: O(log n) due to bubble-down.
        /// Space Complexity: O(1) auxiliary.
        /// </remarks>
        public int Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("PriorityQueue is empty.");

            int root = heap[0];
            heap[0] = heap[^1];
            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
                BubbleDown(0);

            return root;
        }

        /// <summary>
        /// Gets the number of elements stored in the priority queue.
        /// </summary>
        /// <remarks>
        /// Time Complexity: O(1).
        /// Space Complexity: O(1) auxiliary.
        /// </remarks>
        public int Count => heap.Count;

        /// <summary>
        /// Moves the value at the specified index upwards until heap order is restored.
        /// </summary>
        /// <param name="index">The index of the element to bubble up.</param>
        /// <remarks>
        /// Time Complexity: O(log n) in the worst case.
        /// Space Complexity: O(1).
        /// </remarks>
        private void BubbleUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (heap[index] >= heap[parent])
                    break;
                Swap(index, parent);
                index = parent;
            }
        }

        /// <summary>
        /// Moves the value at the specified index downward until heap order is restored.
        /// </summary>
        /// <param name="index">The index of the element to bubble down.</param>
        /// <remarks>
        /// Time Complexity: O(log n) in the worst case.
        /// Space Complexity: O(1).
        /// </remarks>
        private void BubbleDown(int index)
        {
            int lastIndex = heap.Count - 1;

            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = index;

                if (left <= lastIndex && heap[left] < heap[smallest])
                    smallest = left;

                if (right <= lastIndex && heap[right] < heap[smallest])
                    smallest = right;

                if (smallest == index)
                    break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        /// <summary>
        /// Swaps two elements inside the heap list.
        /// </summary>
        /// <param name="i">The index of the first element.</param>
        /// <param name="j">The index of the second element.</param>
        /// <remarks>
        /// Time Complexity: O(1).
        /// Space Complexity: O(1).
        /// </remarks>
        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
