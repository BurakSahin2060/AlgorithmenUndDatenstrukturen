using NUnit.Framework;
using System;
using DataStructureAndSortingTests;

namespace DataStructureAndSortingTests.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new Queue<int>();
        }

        [Test]
        public void Enqueue_AddsElementsCorrectly()
        {
            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.AreEqual(10, queue.Peek());
            Assert.AreEqual(2, queue.Count());
        }

        [Test]
        public void Dequeue_RemovesElementsInFifoOrder()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
        }

        [Test]
        public void Dequeue_OnEmptyQueue_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_OnEmptyQueue_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void IsEmpty_ReturnsTrueWhenEmpty()
        {
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void IsEmpty_ReturnsFalseWhenNotEmpty()
        {
            queue.Enqueue(5);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void Count_ReturnsCorrectNumberOfElements()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count());
        }

        [Test]
        public void Get_ReturnsCorrectElementByIndex()
        {
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.AreEqual(10, queue.Get(0));
            Assert.AreEqual(20, queue.Get(1));
            Assert.AreEqual(30, queue.Get(2));
        }

        [Test]
        public void Get_InvalidIndex_ThrowsException()
        {
            queue.Enqueue(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => queue.Get(5));
        }

        [Test]
        public void Swap_SwapsElementsCorrectly()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Swap(0, 2);

            Assert.AreEqual(3, queue.Get(0));
            Assert.AreEqual(2, queue.Get(1));
            Assert.AreEqual(1, queue.Get(2));
        }

        [Test]
        public void Sort_SortsQueueCorrectly()
        {
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Sort();

            Assert.AreEqual(1, queue.Get(0));
            Assert.AreEqual(2, queue.Get(1));
            Assert.AreEqual(3, queue.Get(2));
        }
    }
}
