using NUnit.Framework;
using DataStructuresToolkit.StacksQueues;
using System;

namespace DataStructuresToolkit.Tests
{
    [TestFixture]
    public class MyQueueTests
    {
        [Test]
        public void Enqueue_IncreasesCount()
        {
            var queue = new MyQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_ReturnsFirstEnqueuedItem_WithoutRemoving()
        {
            var queue = new MyQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);

            var peeked = queue.Peek();

            Assert.That(peeked, Is.EqualTo(10));
            Assert.That(queue.Count, Is.EqualTo(2));
        }

        [Test]
        public void Dequeue_ReturnsFirstEnqueuedItem_AndDecrementsCount()
        {
            var queue = new MyQueue<string>();
            queue.Enqueue("a");
            queue.Enqueue("b");

            var dequeued = queue.Dequeue();

            Assert.That(dequeued, Is.EqualTo("a"));
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            var queue = new MyQueue<double>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            var queue = new MyQueue<char>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void CircularQueue_Wraparound_WorksCorrectly()
        {
            
            var queue = new MyQueue<int>(4);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));

            queue.Enqueue(5);
            queue.Enqueue(6);

            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.Dequeue(), Is.EqualTo(6));

            Assert.That(queue.Count, Is.EqualTo(0));
        }
    }
}
