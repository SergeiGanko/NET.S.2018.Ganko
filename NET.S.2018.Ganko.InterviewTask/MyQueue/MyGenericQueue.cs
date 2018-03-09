// <copyright file="MyGenericQueue.cs" company="Sergei Ganko">
//     Copyright (c) Sergei Ganko. All rights reserved.
// </copyright>
// <author>Sergei Ganko</author>
namespace MyQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Class MyGenericQueue<typeparamref name="T"/>.
    /// A circular-array implementation of a generic queue.
    /// </summary>
    /// <typeparam name="T">A generic type parameter.</typeparam>
    public sealed class MyGenericQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// This constant represents default capasity value
        /// </summary>
        private const int DefaultCapasity = 5;

        /// <summary>
        /// This constant represents increase capasity value
        /// </summary>
        private const int IncreaseCapasity = 5;

        /// <summary>
        /// Field represents a head index of a queue
        /// </summary>
        private int head;

        /// <summary>
        /// Field represents a tail index of a queue
        /// </summary>
        private int tail;

        /// <summary>
        /// Field stores array reference
        /// </summary>
        private T[] array;

        /// <summary>
        /// Field represents count of queue elements
        /// </summary>
        private int count;

        /// <summary>
        /// Initializes a new instance of the MyGenericQueue class 
        /// that is empty and has the default initial capasity.
        /// </summary>
        public MyGenericQueue()
        {
            this.array = new T[0];
        }

        /// <summary>
        /// Initializes a new instance of the MyGenericQueue class 
        /// that is empty and has the specified initial capasity.
        /// </summary>
        /// <param name="capasity">The number of elements that the new queue can initially store.</param>
        public MyGenericQueue(int capasity)
        {
            if (capasity < 0)
            {
                throw new ArgumentOutOfRangeException($"The queue dimension must be > 0");
            }

            this.array = new T[capasity];
            this.tail = 0;
            this.head = 0;
            this.count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the MyGenericQueue class 
        /// that contains elements copied from the specified collection 
        /// and has sufficient capacityto accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the queue.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when capasity parameter is less than 0.</exception>
        public MyGenericQueue(IEnumerable collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Argument contains null");
            }

            this.array = new T[DefaultCapasity];
            this.head = 0;
            this.count = 0;
            this.tail = 0;
            foreach (T item in collection)
            {
                this.Enqueue(item);
            }
        }

        /// <summary>
        /// Gets true if value of count is 0
        /// </summary>
        /// <value></value>
        public bool IsEmpty => this.count == 0;

        /// <summary>
        /// Gets a value of count
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Adds element to queue
        /// </summary>
        /// <param name="t">Generic parameter represents an element which adding to a queue</param>
        public void Enqueue(T t)
        {
            if (this.tail >= this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length + IncreaseCapasity);
            }

            this.count++;
            this.array[this.tail] = t;
            this.tail++;
        }

        /// <summary>
        /// Removes element from queue
        /// </summary>
        /// <returns>Returns the first element of the queue</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when queue is empty.</exception>
        public T Dequeue()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T t = this.array[this.head];
            this.array[this.head] = default(T);
            this.head = (this.head + 1) % this.array.Length;
            this.count--;
            return t;
        }

        /// <summary>
        /// Clears queue
        /// </summary>
        public void Clear()
        {
            if (this.head > this.tail)
            {
                Array.Clear(this.array, this.head, this.array.Length - this.head);
                Array.Clear(this.array, 0, this.tail);
            }
            else
            {
                Array.Clear(this.array, this.head, this.count);
            }
        }

        #region IEnumerable<T> Members

        /// <summary>
        /// Exposes an enumerator
        /// </summary>
        /// <returns>Returns an enumeration of items</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.array)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Exposes an enumerator
        /// </summary>
        /// <returns>Returns an IEnumerator for the array</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
