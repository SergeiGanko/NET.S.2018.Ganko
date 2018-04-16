using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Queue
{
    /// <summary>
    /// Class Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public sealed class Queue<T> : IEnumerable<T>
    {
        #region Constants

        /// <summary>
        /// The default capasity of the queue
        /// </summary>
        private const int defaultCapasity = 10;

        /// <summary>
        /// The value of array size increasing
        /// </summary>
        private const int increaseCapasity = 10;

        #endregion

        #region Fields

        /// <summary>
        /// The array
        /// </summary>
        private T[] array;

        /// <summary>
        /// The head of the queue
        /// </summary>
        private int head;

        /// <summary>
        /// The tail of the queue
        /// </summary>
        private int tail;

        /// <summary>
        /// The count of queue elements
        /// </summary>
        private int count;

        /// <summary>
        /// The version
        /// </summary>
        private int version;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            array = new T[defaultCapasity];
            head = 0;
            tail = 0;
            count = 0;
            version = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="capasity">The capasity.</param>
        /// <exception cref="System.ArgumentException">Throws when capasity is below zero</exception>
        public Queue(int capasity)
        {
            if (capasity < 0)
            {
                throw new ArgumentException($"The queue {nameof(capasity)} must be > 0");
            }

            array = new T[capasity];
            head = 0;
            tail = 0;
            count = 0;
            version = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <exception cref="System.ArgumentNullException">Throws when argument is null</exception>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Argument {nameof(collection)} is null");
            }

            array = new T[collection.Count()];
            count = array.Length;
            head = 0;
            count = 0;
            version = 0;

            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the queue count.
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Gets a value indicating whether this queue is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this queue is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => this.count == 0;


        #endregion

        #region Public Methods

        /// <summary>
        /// Adds item to the tail of queue.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.ArgumentNullException">Throws when item is null</exception>
        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"Argument {nameof(item)} is null");
            }

            T[] newArray = new T[array.Length + increaseCapasity];
            if (count > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newArray, 0, count);
                }
                else
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                }

                array = newArray;
                head = 0;
                tail = (count == array.Length) ? 0 : count;
            }

            array[tail] = item;
            tail = (tail + 1) % array.Length;
            count++;
            version++;
        }

        /// <summary>
        /// Removes item from the head of queue.
        /// </summary>
        /// <returns>Returns the element at the beginning of the queue and removing it from the queue</returns>
        /// <exception cref="System.InvalidOperationException">The queue is empty</exception>
        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T item = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            count--;
            version++;
            return item;
        }

        /// <summary>
        /// Returns the element at the beginning of the queue without removing it
        /// </summary>
        /// <returns>Returns the element at the beginning of the queue without removing it</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException($"The queue is empty");
            }

            return array[head];
        }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        public void Clear()
        {
            if (head < tail)
            {
                Array.Clear(array, head, count);
            }
            else
            {
                Array.Clear(array, head, array.Length - head);
                Array.Clear(array, 0, tail);
            }

            head = 0;
            tail = 0;
            count = 0;
            version++;
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Class Enumerator
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
        private class Enumerator : IEnumerator<T>
        {
            #region Fields

            /// <summary>
            /// The queue
            /// </summary>
            private readonly Queue<T> queue;

            /// <summary>
            /// The version
            /// </summary>
            private readonly int version;

            /// <summary>
            /// The index of the queue
            /// </summary>
            private int index;

            /// <summary>
            /// The current element of queue
            /// </summary>
            private T currentElement;

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> class.
            /// </summary>
            /// <param name="queue">The queue.</param>
            public Enumerator(Queue<T> queue)
            {
                this.queue = queue;
                version = queue.version;
                index = -1;
                currentElement = default(T);
            }

            #endregion

            #region Properties

            public T Current
            {
                get
                {
                    if (this.index == -1)
                    {
                        throw new InvalidOperationException($"Iteration was ended");
                    }

                    return currentElement;
                }
            }

            object IEnumerator.Current => this.Current;

            #endregion

            #region Public Methods

            public bool MoveNext()
            {
                if (this.version != this.queue.version)
                {
                    throw new InvalidOperationException("Queue was changed");
                }

                if (index == -2)
                {
                    return false;
                }

                index++;

                if (index == queue.count)
                {
                    index = -2;
                    currentElement = default(T);
                    return false;
                }

                currentElement = queue.array[index];
                return true;
            }

            public void Reset() => index = -1;

            #endregion

            #region IDisposable implementation

            void IDisposable.Dispose()
            {
            }

            #endregion
        }

        #endregion
    }
}
