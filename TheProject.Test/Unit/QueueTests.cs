using System;
using NUnit.Framework;

namespace TheProject.Test.Unit
{
    public class QueueTests
    {
        private TddQueue queue;
        private const int AnyInteger = 27;

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
        public void NewQueueHasLengthOfZero()
        {
            Assert.AreEqual(0,queue.Length);
        }

        [Test]
        public void DequeuingEmptyQueueThrowsException()
        {
            Assert.Throws<InvalidOperationException>
                (() => queue.Dequeue());
        }

        [Test]
        public void EnqueuingItemIncrementsLength()
        {
            queue.Enqueue(AnyInteger);
            Assert.AreEqual(1,queue.Length);
        }
    }

    public class TddQueue
    {
        public bool IsEmpty { get; } = true;
        public int Length { get; set; }

        public void Enqueue(int i)
        {
            Length++;
        }

        public void Dequeue()
        {
            throw new InvalidOperationException();
        }
    }
}
