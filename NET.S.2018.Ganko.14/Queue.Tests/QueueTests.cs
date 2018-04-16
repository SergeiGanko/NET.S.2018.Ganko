using System;
using NUnit.Framework;

namespace Queue.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private const int capacity = 3;

        [Test]
        public void Constructor_CreateQueueWithoutParameters()
           => Assert.AreEqual(new Queue<int>().Count, 0);

        [Test]
        public void Constructor_CreateQueueFromList()
        {
            int[] array = { 1, 2 };
            var queue = new Queue<int>(array);
            Assert.AreEqual(queue.Count, 2);
        }

        [Test]
        public void Constructor_CreateQueueFromList_ExpectsArgumentNullException()
        {
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => new Queue<int>(array));
        }

        [Test]
        public void Constructor_CreateQueueFixCapacity() 
            => Assert.AreEqual(new Queue<int>(capacity).Count, 0);

        [Test]
        public void Constructor_PassesMinus1AsArgument_ExpectsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Queue<int>(-1));
        }

        [Test]
        public void Enqueue_2ElementsInQueue()
        {
            int[] array = { 1, 2 };

            var queue = new Queue<int>(array);

            queue.Enqueue(3);
            queue.Enqueue(4);

            int expectedCount = 4;
            int actualCount = queue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Dequeue_AllElementsFromQueue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();
            queue.Dequeue();

            int expectedCount = 0;
            int actualCount = queue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Dequeue_ElementFromEmptyQueue_ExpectsInvalidOperationException()
        {
            var queue = new Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_CurrentItemFromQueue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(queue.Peek(), 1);
        }

        [Test]
        public void Peek_FromEmptyQueue_ExpectsInvalidOperationException()
        {
            var queue = new Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void Clear_Queue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Clear();

            Assert.AreEqual(queue.Count, 0);
        }

        [Test]
        public void GetEnumerator_Test()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            var enumerator = queue.GetEnumerator();

            Assert.Throws<InvalidOperationException>(() => { var current = enumerator.Current; });

            foreach (var item in queue)
            {
                Assert.True(enumerator.MoveNext());
            }
            
            Assert.False(enumerator.MoveNext());
            Assert.DoesNotThrow(() => enumerator.Reset());

            queue.Enqueue(3);
            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());

            enumerator = queue.GetEnumerator();
            Assert.Throws<InvalidOperationException>(() => { var current = enumerator.Current; });

            foreach (var item in queue)
            {
                Assert.True(enumerator.MoveNext());
            }

            Assert.AreEqual(3, enumerator.Current);
            Assert.False(enumerator.MoveNext());

            Assert.DoesNotThrow(() => enumerator.Reset());
            Assert.Throws<InvalidOperationException>(() => { var current = enumerator.Current; });

            int i = 1;
            foreach (var item in queue)
            {
                Assert.True(enumerator.MoveNext());
                Assert.AreEqual(i++, enumerator.Current);
            }

            Assert.False(enumerator.MoveNext());
        }
    }
}
