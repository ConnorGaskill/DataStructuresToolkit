MyStack<T>

A generic stack (LIFO) implemented using a resizable array. Supports standard operations such as Push, Pop, and Peek.

Method Complexities:
Method	Time Complexity
Push	O(1) amortized (O(n) when resizing)
Pop	O(1)
Peek	O(1)
Use Cases:

Reversing elements

Undo/redo functionality

Expression evaluation (e.g., parsing)

MyQueue<T>

A generic queue (FIFO) using a circular array with automatic resizing. Supports Enqueue, Dequeue, and Peek.

Method Complexities:
Method	Time Complexity
Enqueue	O(1) amortized (O(n) when resizing)
Dequeue	O(1)
Peek	O(1)
Use Cases:

Task scheduling

Breadth-first search (BFS)

Message buffering