using NUnit.Framework;

namespace TheProject.Test.Unit
{
    public class QueueTests
    {
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
        public void NewQueueHasZeroCount()
        {
            Assert.AreEqual(0,queue.Count);
        }
    }

    public class TddQueue
    {
        public bool IsEmpty { get; } = true;
        public int Count { get; } = 0;
    }
}
