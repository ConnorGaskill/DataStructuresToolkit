using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
    /// <summary>
    /// A generic stack implementation using a resizable array.
    /// Provides standard stack operations: Push, Pop, and Peek.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the stack.</typeparam>
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyStack{T}"/> class with an optional initial capacity.
        /// </summary>
        /// <param name="initialCapacity">The initial number of elements the stack can hold.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="initialCapacity"/> is less than or equal to zero.</exception>
        /// <remarks>Time Complexity: O(1)</remarks>
        public MyStack(int initialCapacity = 4)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be greater than zero");
            }

            _items = new T[initialCapacity];
            _count = 0;
        }

        /// <summary>
        /// Gets the number of elements currently in the stack.
        /// </summary>
        /// <remarks>Time Complexity: O(1)</remarks>
        public int Count => _count;

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="item">The item to push onto the stack.</param>
        /// <remarks>
        /// Time Complexity: Amortized O(1); O(n) when resizing is required.
        /// </remarks>
        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }

            _items[_count++] = item;
        }

        /// <summary>
        /// Removes and returns the element at the top of the stack.
        /// </summary>
        /// <returns>The element removed from the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        /// <remarks>Time Complexity: O(1)</remarks>
        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot pop from an empty stack");

            _count--;
            T item = _items[_count];
            _items[_count] = default;
            return item;
        }

        /// <summary>
        /// Returns the element at the top of the stack without removing it.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        /// <remarks>Time Complexity: O(1)</remarks>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot peek an empty stack");

            return _items[_count - 1];
        }

        /// <summary>
        /// Resizes the internal array to the specified new size.
        /// </summary>
        /// <param name="newSize">The new size for the internal array.</param>
        /// <remarks>Time Complexity: O(n), where n is the number of elements currently in the stack.</remarks>
        private void Resize(int newSize)
        {
            T[] newArr = new T[newSize];
            Array.Copy(_items, newArr, _count);
            _items = newArr;
        }
    }
}
