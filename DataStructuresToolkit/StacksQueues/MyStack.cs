using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;

        public MyStack(int initialCapacity = 4) { 

            if (initialCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be greater than zero");

            }
                _items = new T[initialCapacity];
                _count = 0;
        
        }

        public int Count => _count;

        public void Push(T item) {

            if (_count == _items.Length) { 
                Resize(_items.Length * 2);
            }

            _items[_count++] = item;
        }

        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot pop from an empty stack");

            _count--;
            T item = _items[_count];
            _items[_count] = default;
            return item;
        }

        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot peek an empty stack");

            return _items[_count - 1];
        }
        

        private void Resize(int newSize)
        {
            T[] newArr = new T[newSize];
            Array.Copy(_items, newArr, _count);
            _items = newArr;
        }
    }
}
