using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TheProject.Test.Unit
{
    public class QueueTest
    {

        private const int AnyInteger = 12;
        private const int SecondInteger = 13;
        private TddQueue _queue;

        [SetUp]
        public void SetUp()
        {
            _queue = new TddQueue();
        }
        [Test]
        public void NewQueueIsEmpty()
        {
            Assert.IsTrue(_queue.IsEmpty());
        }
       

        [Test]
        public void NewQueueHasLengthOfZero()
        {
            Assert.AreEqual(0, _queue.Length);
        }

        [Test]
        public void EnqueuingItemIncrementsLength()
        {
            _queue.Enqueue(AnyInteger);
            Assert.AreEqual(1, _queue.Length);
        }
        [Test]
        public void DequeueingItemDecrementsLength()
        {
            _queue.Enqueue((AnyInteger));
            _queue.Dequeue();
            Assert.AreEqual(0,_queue.Length);
        }

        [Test]
        public void GetHeadElementReturnsFirstElement()
        {
            _queue.Enqueue(AnyInteger);
            _queue.Enqueue(SecondInteger);
            Assert.AreEqual(AnyInteger, _queue.GetHeadElement());
        }

        [Test]
        public void GetHeadElementThrowsExceptionForEmptyQueue()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.GetHeadElement());
        }

        [Test]
        public void DequeueingEmptyQueueThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
        }

        [Test]
        public void EnqueuingMoreThanFiveDoesNotThrowException()
        {
            for (int i = 0; i <= 7; i++)
            {
                _queue.Enqueue((i));
            }
            Assert.IsTrue(true);
        }

        [Test]
        public void EnquuingANegativeNumberThrowsAnArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _queue.Enqueue(-1));
        }

        [Test]
        public void EnqueuingAnIntegerGreaterThan99ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _queue.Enqueue(100));
        }
       
    }

    public class TddQueue
    {
        private IList<int> Elements = new List<int>();
        private string CannotAddMore = "Cannot add more than 5 items to the queue";
        
        private string ArgumentOutOfRangeError= "Queue elements cannot be less than zero";

        public bool IsEmpty()
        {
            return Elements.Count == 0;
        }


        public int Length => Elements.Count;

        public void Enqueue(int i)
        {
            if(i < 0  || i > 99)
                throw new ArgumentOutOfRangeException(ArgumentOutOfRangeError);
            Elements.Add((i));
        }

        public void Dequeue()
        {
            if(Elements.Count  > 0)
                Elements.RemoveAt(0);
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int GetHeadElement()
        {
            if (Elements.Count > 0)
                return Elements[0];
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
