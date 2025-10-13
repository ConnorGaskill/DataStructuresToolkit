using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
    public class MyQueue<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public MyQueue(int initialCapacity = 4) {
            if (initialCapacity < 1)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be greater than zero");

            _items = new T[initialCapacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public int Count => _count;

        public void Enqueue(T item)
        {
            if(_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }

            _items[_tail] = item;
            _tail = (_tail + 1 ) % _items.Length;
            _count++;
        }

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
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot peek an empty queue");

            return _items[_head];
        }

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
