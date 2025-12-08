using DataStructuresToolkit;
using DataStructuresToolkit.DataStructures.AvlTrees;
using DataStructuresToolkit.DataStructures.GraphToolkit;
using DataStructuresToolkit.DataStructures.StackQueues;
using DataStructuresToolkit.DataStructures.StacksQueues;
using DataStructuresUtilities;
using LinkedListHelpers;

namespace DemoHarness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestStackQueues();
            //TestSearches();
            //TestSorts();
            //TestAvlTree();
            //TestPriorityQueue();
            TimeTestPriorityQueueVsAvlTree();
            //TestHashTableAndAssociativeHelpers();
            //TestCustomLinkedLists();
            //TestGraphTraversals();

        }

        static void TestStackQueues ()
        {
            List<string> names = DataStructuresUtilities.RandomUtilities.GenerateRandomNamesList(10);

            MyStack<string> myStack = new MyStack<string>();

            foreach (string name in names)
            {
                Console.WriteLine("Pushing: " + name);
                myStack.Push(name);
                Console.WriteLine(myStack.Count);
            }

            try
            {
                while (true)
                {
                    Console.WriteLine(myStack.Pop());
                }

            }
            catch (Exception ex) { }

            MyQueue<string> myQueue = new MyQueue<string>();

            foreach (string name in names)
            {
                Console.WriteLine("Enqueuing: " + name);
                myQueue.Enqueue(name);
                Console.WriteLine(myQueue.Count);
            }

            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }

        /// <summary>
        /// 1000 Fastest: binary search
        /// 10000 Fastest: binary search
        /// 100000 Fastest: binary search
        /// 
        /// </summary>
        static void TestSearches ()
        {
            Console.WriteLine("\nTesting searches\n");

            int[] arr1000 = Enumerable.Range(1, 1000).ToArray();

            int[] arr10000 = Enumerable.Range(1, 10000).ToArray();

            int[] arr100000 = Enumerable.Range(1, 100000).ToArray();


            TimeSpan linearSearchTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.LinearSearch(arr1000, 500));

            TimeSpan binarySearchTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.BinarySearch(arr1000, 500));

            Console.WriteLine("1000 elements\n");

            Console.WriteLine(DataStructuresUtilities.TimeUtilities.GetFastest(

                new KeyValuePair<string, TimeSpan>("linear search", linearSearchTime), new KeyValuePair<string, TimeSpan>("binary search", binarySearchTime)));

            linearSearchTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.LinearSearch(arr10000, 5000));

            binarySearchTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.BinarySearch(arr10000, 5000));

            Console.WriteLine("\n10000 elements\n");

            Console.WriteLine(DataStructuresUtilities.TimeUtilities.GetFastest(

                new KeyValuePair<string, TimeSpan>("linear search", linearSearchTime), new KeyValuePair<string, TimeSpan>("binary search", binarySearchTime)));

            linearSearchTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.LinearSearch(arr100000, 50000));

            binarySearchTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.BinarySearch(arr100000, 50000));

            Console.WriteLine("\n100000 elements\n");

            Console.WriteLine(DataStructuresUtilities.TimeUtilities.GetFastest(

                new KeyValuePair<string, TimeSpan>("linear search", linearSearchTime), new KeyValuePair<string, TimeSpan>("binary search", binarySearchTime)));

            Console.ReadLine();


        }

        /// <summary>
        /// 1000 Fastest: bubble sort
        /// 10000 Fastest: merge sort
        /// 100000 Fastest: merge sort
        /// </summary>
        static void TestSorts ()
        {

            Console.WriteLine("\nTesting sorts\n");

            int[] arr1000 = DataStructuresUtilities.RandomUtilities.GenerateRandomArray(1000, 1, 1000);

            int[] arr10000 = DataStructuresUtilities.RandomUtilities.GenerateRandomArray(10000, 1, 1000);

            int[] arr100000 = DataStructuresUtilities.RandomUtilities.GenerateRandomArray(100000, 1, 1000);

            TimeSpan mergeSortTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.MergeSort(arr1000));

            DataStructuresUtilities.RandomUtilities.Shuffle(arr1000);

            TimeSpan bubbleSortTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.BubbleSort(arr1000));

            Console.WriteLine("1000 elements\n");

            Console.WriteLine(DataStructuresUtilities.TimeUtilities.GetFastest(

                new KeyValuePair<string, TimeSpan>("bubble sort", bubbleSortTime), new KeyValuePair<string, TimeSpan>("merge sort", mergeSortTime)));

            mergeSortTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.MergeSort(arr10000));

            DataStructuresUtilities.RandomUtilities.Shuffle(arr10000);

            bubbleSortTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.BubbleSort(arr10000));

            Console.WriteLine("\n10000 elements\n");

            Console.WriteLine(DataStructuresUtilities.TimeUtilities.GetFastest(

                new KeyValuePair<string, TimeSpan>("bubble sort", bubbleSortTime), new KeyValuePair<string, TimeSpan>("merge sort", mergeSortTime)));

            mergeSortTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.MergeSort(arr100000));

            DataStructuresUtilities.RandomUtilities.Shuffle(arr100000);

            bubbleSortTime = DataStructuresUtilities.TimeUtilities.RunWithStopwatch(() => SortingSearchingHelpers.BubbleSort(arr100000));

            Console.WriteLine("\n100000 elements\n");

            Console.WriteLine(DataStructuresUtilities.TimeUtilities.GetFastest(

                new KeyValuePair<string, TimeSpan>("bubble sort", bubbleSortTime), new KeyValuePair<string, TimeSpan>("merge sort", mergeSortTime)));

            Console.ReadLine();

        }

        static void TestAvlTree()
        {
            Console.WriteLine("Building skewed tree: 10 → 20 → 30 (right-heavy)");

            AVLTree tree = AVLTree.BuildSkewedTree();

            tree.PrintTree(tree.Root);

            tree.PrintBalanceFactors(tree.Root);

            Console.WriteLine("Rebalancing tree...");

            tree.Root = tree.Rebalance(tree.Root);

            Console.WriteLine("Rebalanced Tree:");

            tree.PrintTree(tree.Root);

            tree.PrintBalanceFactors(tree.Root);

        }

        static void TestPriorityQueue()
        {
            PriorityQueue pq = new PriorityQueue();

            Console.WriteLine("Testing priority queues");

            Console.WriteLine("Enqueuing 5");
            pq.Enqueue(5);
            Console.WriteLine("Enqueuing 2");
            pq.Enqueue(2);
            Console.WriteLine("Enqueuing 8");
            pq.Enqueue(8);

            int first = pq.Dequeue();

            Console.WriteLine("First dequeued value: " + first);
            Console.WriteLine(first == 2 ? "PASS" : "FAIL");
        }

        static void TimeTestPriorityQueueVsAvlTree()
        {
            int size = 10000;

            int[] values = RandomUtilities.GenerateRandomArray(size, 1, size);

            AVLTree avl = new AVLTree();
            PriorityQueue pq = new PriorityQueue();

            TimeSpan avlInsert = TimeUtilities.RunWithStopwatch(() =>
            {
                foreach (int i in values)
                    avl.Root = avl.InsertBalanced(avl.Root, i);
            });

            TimeSpan pqInsert = TimeUtilities.RunWithStopwatch(() =>
            {
                foreach (int i in values)
                    pq.Enqueue(i);
            });

            int searchValue = values[size / 2];

            TimeSpan avlSearch = TimeUtilities.RunWithStopwatch(() =>
            {
                avl.Contains(searchValue);
            });

            TimeSpan pqDequeue = TimeUtilities.RunWithStopwatch(() =>
            {
                pq.Dequeue();
            });

            Console.WriteLine("AVL Insert: " + avlInsert);
            Console.WriteLine("PQ Insert: " + pqInsert);

            Console.WriteLine("\n" + TimeUtilities.GetFastest(
                new KeyValuePair<string, TimeSpan>("AVL Insert", avlInsert),
                new KeyValuePair<string, TimeSpan>("PQ Insert", pqInsert)
            ));

            Console.WriteLine("\nAVL Search (Contains): " + avlSearch);
            Console.WriteLine("PQ Dequeue (min extract): " + pqDequeue);

            Console.WriteLine();
            Console.WriteLine(TimeUtilities.GetFastest(
                new KeyValuePair<string, TimeSpan>("AVL Search", avlSearch),
                new KeyValuePair<string, TimeSpan>("PQ Dequeue", pqDequeue)
            ));
        }

        public static void TestHashTableAndAssociativeHelpers()
        {
            Console.WriteLine("SimpleHashTable Collision Demo");
            SimpleHashTable.Demo();

            Console.WriteLine();
            Console.WriteLine("AssociativeHelpers Demo");

            // Reset static data to ensure clean test runs
            AssociativeHelpers.Reset();

            AssociativeHelpers.AddContact("Alice", "555-1234");
            AssociativeHelpers.AddContact("Bob", "555-9876");

            // Demonstrate dictionary overwrite
            AssociativeHelpers.AddContact("Alice", "555-0000");

            Console.WriteLine();
            AssociativeHelpers.CheckContact("Alice");

            Console.WriteLine();
            AssociativeHelpers.CheckContact("Charlie");

            Console.WriteLine();
            AssociativeHelpers.PrintData();
        }

        static void TestGraphTraversals()
        {

            var chainingGraphData = new Dictionary<string, List<string>>
            {
                { "V0",  new List<string>{ "V1", "V2", "V3", "V4", "V5", "V6" } },
                { "V1",  new List<string>{ "V7" } },
                { "V2",  new List<string>{ "V8" } },
                { "V3",  new List<string>{ "V9" } },
                { "V4",  new List<string>{ "V10" } },
                { "V5",  new List<string>{ "V11" } },
                { "V6",  new List<string>() },
                { "V7",  new List<string>() },
                { "V8",  new List<string>() },
                { "V9",  new List<string>() },
                { "V10", new List<string>() },
                { "V11", new List<string>() }
            };


            var branchingGraphData = new Dictionary<string, List<string>>
            {
                { "V0",  new List<string>{ "V1", "V5" } },
                { "V1",  new List<string>{ "V2" } },
                { "V2",  new List<string>{ "V3" } },
                { "V3",  new List<string>{ "V4", "V9" } },
                { "V4",  new List<string>{ "V5" } },
                { "V5",  new List<string>{ "V6" } },
                { "V6",  new List<string>{ "V7", "V2" } },
                { "V7",  new List<string>{ "V8" } },
                { "V8",  new List<string>{ "V9", "V11" } },
                { "V9",  new List<string>{ "V10" } },
                { "V10", new List<string>{ "V11" } },
                { "V11", new List<string>() }
            };

            MyGraph DFSFaster = new MyGraph(chainingGraphData);

            MyGraph BFSFaster = new MyGraph(branchingGraphData);

            Console.WriteLine("Chaining graph test (DFS advantage)");

            Console.WriteLine("BFS Traversal");

            TimeSpan ts1 = TimeUtilities.RunWithStopwatch(() => GraphHelpers.BFS("V0", DFSFaster));

            Console.WriteLine("DFS Traversal");

            TimeSpan ts2 = TimeUtilities.RunWithStopwatch(() => GraphHelpers.DFS("V0", DFSFaster));

            Console.WriteLine($"Times:\nBFS: {ts1}\nDFS {ts2}");

            Console.WriteLine("Compare:");

            Console.WriteLine(
                TimeUtilities.GetFastest(
                new KeyValuePair<string, TimeSpan> ("BFS", ts1), new KeyValuePair<string, TimeSpan> ("DFS", ts2 )
                )    
            );

            ///////////////////////
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("Branching graph test (BFS advantage)");

            Console.WriteLine("BFS Traversal");

            ts1 = TimeUtilities.RunWithStopwatch(() => GraphHelpers.BFS("V0", DFSFaster));

            Console.WriteLine("DFS Traversal");

            ts2 = TimeUtilities.RunWithStopwatch(() => GraphHelpers.DFS("V0", DFSFaster));

            Console.WriteLine($"Times:\nBFS: {ts1}\nDFS {ts2}");

            Console.WriteLine("Compare:");

            Console.WriteLine(
                TimeUtilities.GetFastest(
                new KeyValuePair<string, TimeSpan>("BFS", ts1), new KeyValuePair<string, TimeSpan>("DFS", ts2)
                )
            );
        }

        static void TestCustomLinkedLists()
        {
            Console.WriteLine("SinglyLinkedList<int>");
            var singlyList = new SinglyLinkedList<int>();
            singlyList.AddFirst(30);
            singlyList.AddFirst(20);
            singlyList.AddFirst(10);

            Console.WriteLine("Traversal order:");
            foreach (var value in singlyList.Values())
            {
                Console.Write(value + " -> ");
            }
            Console.WriteLine("null\n");

            Console.WriteLine("DoublyLinkedList<string>");
            var doublyList = new DoublyLinkedList<string>();
            doublyList.AddFirst("middle");
            doublyList.AddFirst("start");
            doublyList.AddLast("end");

            Console.WriteLine("Forward traversal:");
            foreach (var value in doublyList.ValuesForward())
            {
                Console.Write(value + " -> ");
            }
            Console.WriteLine("null");

            Console.WriteLine("Backward traversal:");
            foreach (var value in doublyList.ValuesBackward())
            {
                Console.Write(value + " -> ");
            }
            Console.WriteLine("null");

            Console.WriteLine("\nRemove middle and traverse forward again:");
            doublyList.Remove("middle");
            foreach (var value in doublyList.ValuesForward())
            {
                Console.Write(value + " -> ");
            }
            Console.WriteLine("null\n");

            Console.WriteLine("Built-in LinkedList<int>");
            var builtInList = new LinkedList<int>();
            builtInList.AddLast(10);
            builtInList.AddLast(20);
            builtInList.AddFirst(5);

            Console.WriteLine("Traversal:");
            foreach (var value in builtInList)
            {
                Console.Write(value + " -> ");
            }
            Console.WriteLine("null");

            Console.WriteLine("Remove 20 and traverse again:");
            builtInList.Remove(20);
            foreach (var value in builtInList)
            {
                Console.Write(value + " -> ");
            }
            Console.WriteLine("null");
        }
    }
}
