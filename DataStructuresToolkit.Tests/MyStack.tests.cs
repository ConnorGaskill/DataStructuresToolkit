using NUnit.Framework;
using System;
using DataStructuresToolkit.DataStructures.StacksQueues;

namespace DataStructuresToolkit.Tests.StacksQueues
{
    [TestFixture]
    public class MyStackTests
    {
        [Test]
        public void Push_IncreasesCount()
        {
            var stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_ReturnsLastPushedItem()
        {
            var stack = new MyStack<int>();

            stack.Push(100);
            stack.Push(200);

            int peeked = stack.Peek();

            Assert.That(peeked, Is.EqualTo(200));
        }

        [Test]
        public void Pop_ReturnsLastPushedItem()
        {
            var stack = new MyStack<string>();

            stack.Push("first");
            stack.Push("second");

            string popped = stack.Pop();

            Assert.That(popped, Is.EqualTo("second"));
        }

        [Test]
        public void Pop_DecreasesCount()
        {
            var stack = new MyStack<string>();

            stack.Push("item");

            int countBefore = stack.Count;
            stack.Pop();
            int countAfter = stack.Count;

            Assert.That(countAfter, Is.EqualTo(countBefore - 1));
        }

        [Test]
        public void Peek_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new MyStack<double>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new MyStack<object>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Stack_Resizes_WhenCapacityExceeded()
        {
            var stack = new MyStack<int>(2);

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Assert.That(stack.Count, Is.EqualTo(10));
        }

        [Test]
        public void Peek_AfterResize_ReturnsLastItem()
        {
            var stack = new MyStack<int>(2);

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            int peeked = stack.Peek();

            Assert.That(peeked, Is.EqualTo(9));
        }
    }
}
