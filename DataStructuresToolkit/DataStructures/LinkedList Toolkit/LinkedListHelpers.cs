using System;
using System.Collections.Generic;

namespace LinkedListHelpers
{
    /// <summary>
    /// Represents a node in a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the node.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// The data stored in the node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Reference to the next node in the list.
        /// </summary>
        public Node<T>? Next { get; set; }

        /// <summary>
        /// Initializes a new node with the specified data.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// Represents a node in a doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the node.</typeparam>
    public class DoublyNode<T>
    {
        /// <summary>
        /// The data stored in the node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Reference to the next node in the list.
        /// </summary>
        public DoublyNode<T>? Next { get; set; }

        /// <summary>
        /// Reference to the previous node in the list.
        /// </summary>
        public DoublyNode<T>? Previous { get; set; }

        /// <summary>
        /// Initializes a new node with the specified data.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        public DoublyNode(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    /// <summary>
    /// Represents a generic singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class SinglyLinkedList<T>
    {
        private Node<T>? head;

        /// <summary>
        /// Adds a new element at the beginning of the list.
        /// </summary>
        /// <param name="data">The data to add.</param>
        /// <remarks>
        /// Complexity: O(1)
        /// </remarks>
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data) { Next = head };
            head = newNode;
        }

        /// <summary>
        /// Determines whether the list contains a specific value.
        /// </summary>
        /// <param name="data">The value to locate in the list.</param>
        /// <returns>True if the value is found; otherwise, false.</returns>
        /// <remarks>
        /// Complexity: O(n), where n is the number of elements in the list.
        /// </remarks>
        public bool Contains(T data)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerable of all values in the list in forward order.
        /// </summary>
        /// <returns>An IEnumerable of values.</returns>
        /// <remarks>
        /// Complexity: O(n)
        /// </remarks>
        public IEnumerable<T> Values()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    /// <summary>
    /// Represents a generic doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class DoublyLinkedList<T>
    {
        private DoublyNode<T>? head;
        private DoublyNode<T>? tail;

        /// <summary>
        /// Adds a new element at the beginning of the list.
        /// </summary>
        /// <param name="data">The data to add.</param>
        /// <remarks>
        /// Complexity: O(1)
        /// </remarks>
        public void AddFirst(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
        }

        /// <summary>
        /// Adds a new element at the end of the list.
        /// </summary>
        /// <param name="data">The data to add.</param>
        /// <remarks>
        /// Complexity: O(1)
        /// </remarks>
        public void AddLast(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific value from the list.
        /// </summary>
        /// <param name="data">The value to remove.</param>
        /// <returns>True if the element was found and removed; otherwise, false.</returns>
        /// <remarks>
        /// Complexity: O(n)
        /// </remarks>
        public bool Remove(T data)
        {
            DoublyNode<T>? current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        tail = current.Previous;

                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerable of all values in the list in forward order.
        /// </summary>
        /// <returns>An IEnumerable of values.</returns>
        /// <remarks>
        /// Complexity: O(n)
        /// </remarks>
        public IEnumerable<T> ValuesForward()
        {
            DoublyNode<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns an enumerable of all values in the list in backward order.
        /// </summary>
        /// <returns>An IEnumerable of values.</returns>
        /// <remarks>
        /// Complexity: O(n)
        /// </remarks>
        public IEnumerable<T> ValuesBackward()
        {
            DoublyNode<T>? current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }

    /// <summary>
    /// Represents a generic circular singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class CircularLinkedList<T>
    {
        private Node<T>? head;

        /// <summary>
        /// Adds a new element at the beginning of the circular list.
        /// </summary>
        /// <param name="data">The data to add.</param>
        /// <remarks>
        /// Complexity: O(n) due to traversal to find tail.
        /// </remarks>
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
            }
            else
            {
                Node<T> tail = head;
                while (tail.Next != head)
                    tail = tail.Next;

                newNode.Next = head;
                head = newNode;
                tail.Next = head;
            }
        }

        /// <summary>
        /// Returns an enumerable of values in the circular list, wrapping around a specified number of times.
        /// </summary>
        /// <param name="count">The number of elements to iterate (can be multiple loops).</param>
        /// <returns>An IEnumerable of values.</returns>
        /// <remarks>
        /// Complexity: O(n)
        /// </remarks>
        public IEnumerable<T> Values(int count)
        {
            if (head == null) yield break;

            Node<T> current = head;
            for (int i = 0; i < count; i++)
            {
                yield return current.Data;
                current = current.Next!;
            }
        }
    }
}
