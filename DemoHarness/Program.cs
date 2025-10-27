using DataStructuresToolkit.StacksQueues;
namespace DemoHarness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestStackQueues();



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

        static void TestSearches ()
        {

        }

        static void TestSorts ()
        {


        }

    }
}
