DATASTRUCTURESTOOLKIT

DataStructuresToolkit is a C# library and demo harness providing implementations of fundamental 
data structures, sorting/searching algorithms, and utility functions for benchmarking and random 
data generation. It also includes performance testing and example usage through a console application 
and NUnit test suite.

FEATURES

Data Structures

Stacks and Queues: MyStack<T> and MyQueue<T> implementations.

Linked Lists: Singly and doubly linked lists (SinglyLinkedList<T>, DoublyLinkedList<T>).

AVL Trees: Balanced binary search tree with insertion and rebalancing.

Priority Queue: Min-heap based implementation.

Graphs: Directed graphs with BFS and DFS traversal helpers.

Hash Tables: Simple hash table and associative helper utilities.

Algorithms

Searches

Linear search

Binary search (requires sorted input)

Sorting

Bubble Sort

Merge Sort

Utilities

Random data generators: integer arrays and names (arrays/lists).

Performance timing helpers (TimeUtilities) to compare algorithm execution times.

DEMO HARNESS

The DemoHarness console application demonstrates the usage of each component:

Stack and queue operations

Sorting and searching comparisons

AVL tree insertion and rebalancing

Priority queue operations

Graph BFS/DFS traversals with timing comparisons

Custom linked list operations

Hash table and associative helper examples

Uncomment tests in Program.Main to explore individual features.

PERFORMANCE TESTING

TimeUtilities allows timing and comparing algorithm execution.

ComplexityTesterTests (NUnit) validates time complexity empirically:

Constant: O(1)

Linear: O(n)

Quadratic: O(n^2)

Note: Some complexity tests are marked [Ignore("Too Slow")] to prevent long-running CI builds.

GETTING STARTED

Clone the repository:
git clone <repository-url>
cd DataStructuresToolkit

Build the solution in Visual Studio or via CLI:
dotnet build

Run the demo console:
dotnet run --project DemoHarness

Run tests (NUnit):
dotnet test

PROJECT STRUCTURE

DataStructuresToolkit/
Core data structures and algorithms

DataStructuresUtilities/
Random generators and timing utilities

DemoHarness/
Console demo application

DataStructuresToolkit.Tests/
NUnit test suite for correctness and performance

README.txt
Project documentation

LICENSE

MIT License – free to use, modify, and distribute.