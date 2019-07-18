

using System.Collections.Generic;
using NUnit.Framework;

namespace TheProject.Test.Unit
{

    public class QueueTest
    {
        private const int AnyValidInteger = 43;
        private TddQueue queue;

        [SetUp]
        public void SetUp()
        {
            queue = new TddQueue();
        }

        [Test]
        public void NewQueueIsEmpty()
        {
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void NewQueueHasZeroSize()
        {
            Assert.AreEqual(0, queue.Size);
        }

        [Test]
        public void QueueIsNotEmptyAfterItemAdded()
        {
            queue.Add(AnyValidInteger);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void FirstItemAddedIsHead()
        {
            queue.Add(AnyValidInteger);
            Assert.AreEqual(AnyValidInteger, queue.Head);
        }

        [Test]
        public void ItemAddedIsTail()
        {
            queue.Add(AnyValidInteger);
            Assert.AreEqual(AnyValidInteger, queue.Tail);
        }

        [Test]
        public void AddingItemIncrementsSize()
        {
            queue.Add(AnyValidInteger);
            Assert.AreEqual(1, queue.Size);
        }

        [Test]
        public void RemovingItemChangesHead()
        {
            queue.Add(23);
            queue.Add(21);
            queue.RemoveHead();
            Assert.AreEqual(21, queue.Head);
        }

        [Test]
        public void RemovingItemDecrementsSize()
        {
            queue.Add(AnyValidInteger);
            queue.Add(AnyValidInteger);
            queue.Add(AnyValidInteger);
            queue.Add(AnyValidInteger);
            queue.RemoveHead();
            Assert.AreEqual(3, queue.Size);
        }
    }

    public class TddQueue
    {
        private readonly List<int> queue = new List<int>();
        public bool IsEmpty => Size == 0;
        public int Size => queue.Count;
        public int Head => queue[0];
        public int Tail => queue[Size - 1];

        public void Add(int item)
        {
            queue.Add(item);
        }

        public void RemoveHead()
        {
            queue.RemoveAt(0);
        }
    }
}
