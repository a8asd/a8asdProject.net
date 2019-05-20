using NUnit.Framework;

namespace TheProject.Test.Unit
{
    [TestFixture]
    public class TddQueueTest
    {
        private const int AnyInRangeValue = 37;
        private TddQueue queue;

        [SetUp]
        public void SetUp()
        {
            queue = new TddQueue();
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0,queue.Size);
        }
        [Test]
        public void SizeIncreasesAfterAdd()
        {
            var initialValue = queue.Size;
            queue.Add(AnyInRangeValue);

            Assert.AreEqual(initialValue+1,queue.Size);
        }

        [Test]
        public void FirstItemAddedBecomesHead()
        {
            queue.Add(AnyInRangeValue);
            Assert.AreEqual(AnyInRangeValue,queue.Head);
        }

        [Test]
        public void EmptyIsFalseAfterAddingAnItem()
        {
            queue.Add(AnyInRangeValue);
            Assert.IsFalse(queue.IsEmpty);
        }
    }

    public class TddQueue
    {
        public int Size { get; private set; }
        public int Head { get; private set; }
        public bool IsEmpty { get; private set; }

        public TddQueue()
        {
            IsEmpty = true;
        }
        public void Add(int i)
        {
            Size++;
            Head = i;
            IsEmpty = false;
        }
    }
}
