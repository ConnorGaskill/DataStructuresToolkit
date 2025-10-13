using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
    /// <summary>
    /// A generic queue implementation using a circular array.
    /// Automatically resizes when the internal array is full.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the queue.</typeparam>
    public class MyQueue<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyQueue{T}"/> class with an optional initial capacity.
        /// </summary>
        /// <param name="initialCapacity">Initial size of the internal array. Must be greater than zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="initialCapacity"/> is less than 1.</exception>
        /// <remarks>Time Complexity: O(1)</remarks>
        public MyQueue(int initialCapacity = 4)
        {
            if (initialCapacity < 1)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be greater than zero");

            _items = new T[initialCapacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Gets the number of elements currently stored in the queue.
        /// </summary>
        /// <remarks>Time Complexity: O(1)</remarks>
        public int Count => _count;

        /// <summary>
        /// Adds an element to the end of the queue.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        /// <remarks>
        /// Time Complexity: Amortized O(1); O(n) when resizing is required.
        /// </remarks>
        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }

            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        /// <summary>
        /// Removes and returns the element at the front of the queue.
        /// </summary>
        /// <returns>The element removed from the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when attempting to dequeue from an empty queue.</exception>
        /// <remarks>Time Complexity: O(1)</remarks>
        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot dequeue from an empty queue");

            T item = _items[_head];
            _items[_head] = default;
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;
        }

        /// <summary>
        /// Returns the element at the front of the queue without removing it.
        /// </summary>
        /// <returns>The element currently at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when attempting to peek into an empty queue.</exception>
        /// <remarks>Time Complexity: O(1)</remarks>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot peek an empty queue");

            return _items[_head];
        }

        /// <summary>
        /// Resizes the internal array to the specified new size and reorders elements.
        /// </summary>
        /// <param name="newSize">The new size of the internal array.</param>
        /// <remarks>Time Complexity: O(n), where n is the number of elements in the queue.</remarks>
        private void Resize(int newSize)
        {
            T[] newArr = new T[newSize];

            for (int i = 0; i < _count; i++)
            {
                newArr[i] = _items[(_head + i) % _items.Length];
            }

            _items = newArr;
            _head = 0;
            _tail = _count;
        }
    }
}
