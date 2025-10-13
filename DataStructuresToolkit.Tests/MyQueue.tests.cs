using NUnit.Framework;
using System;
using DataStructuresToolkit.StacksQueues;

namespace DataStructuresToolkit.Tests.StacksQueues
{
    [TestFixture]
    public class MyQueueTests
    {
        [Test]
        public void Constructor_WithValidCapacity_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new MyQueue<int>(5));
        }

        [Test]
        public void Constructor_WithInvalidCapacity_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MyQueue<int>(0));
        }

        [Test]
        public void Count_OnNewQueue_IsZero()
        {
            var queue = new MyQueue<string>();
            Assert.That(queue.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enqueue_SingleItem_IncreasesCountToOne()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(10);

            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enqueue_MultipleItems_MaintainsCorrectOrder()
        {
            var queue = new MyQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");

            string firstOut = queue.Dequeue();

            Assert.That(firstOut, Is.EqualTo("first"));
        }

        [Test]
        public void Dequeue_ReturnsAndRemovesFirstItem()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            int dequeued = queue.Dequeue();

            Assert.That(dequeued, Is.EqualTo(1));
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Dequeue_OnEmptyQueue_ThrowsException()
        {
            var queue = new MyQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_ReturnsFirstItemWithoutRemoving()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(99);
            queue.Enqueue(100);

            int peeked = queue.Peek();

            Assert.That(peeked, Is.EqualTo(99));
            Assert.That(queue.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_OnEmptyQueue_ThrowsException()
        {
            var queue = new MyQueue<string>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void Enqueue_WhenFull_TriggersResizeAndPreservesOrder()
        {
            var queue = new MyQueue<int>(2);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int first = queue.Dequeue();
            int second = queue.Dequeue();
            int third = queue.Dequeue();

            Assert.That(first, Is.EqualTo(1));
            Assert.That(second, Is.EqualTo(2));
            Assert.That(third, Is.EqualTo(3));
        }

        [Test]
        public void Enqueue_Dequeue_Enqueue_MaintainsCorrectHeadTailLogic()
        {
            var queue = new MyQueue<string>(3);

            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");

            queue.Dequeue();
            queue.Enqueue("d");

            string first = queue.Dequeue();
            string second = queue.Dequeue();
            string third = queue.Dequeue();

            Assert.That(first, Is.EqualTo("b"));
            Assert.That(second, Is.EqualTo("c"));
            Assert.That(third, Is.EqualTo("d"));
        }

        [Test]
        public void Count_AfterMultipleOperations_IsAccurate()
        {
            var queue = new MyQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Enqueue(3);

            Assert.That(queue.Count, Is.EqualTo(2));
        }
    }
}
