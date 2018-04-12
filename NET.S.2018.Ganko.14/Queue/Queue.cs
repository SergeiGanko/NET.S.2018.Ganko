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
        /// <summary>
        /// The default capasity of the queue
        /// </summary>
        private const int defaultCapasity = 10;

        /// <summary>
        /// The value of array size increasing
        /// </summary>
        private const int increaseCapasity = 10;

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
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            array = new T[defaultCapasity];
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

            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

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
        public bool IsEmpty => count == 0;

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
        }

        #region IEnumerable<T> Members

        // TODO: Implement iterator whithout yield
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion


    }
}
