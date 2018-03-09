// <copyright file="MyQueueOfStrings.cs" company="Sergei Ganko">
//     Copyright (c) Sergei Ganko. All rights reserved.
// </copyright>
// <author>Sergei Ganko</author>
namespace MyQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Class MyQueueOfStrings.
    /// A circular-array implementation of a queue of strings.
    /// </summary>
    public sealed class MyQueueOfStrings : IEnumerable<string>
    {
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
        private string[] array;

        /// <summary>
        /// Field represents count of queue elements
        /// </summary>
        private int count;

        /// <summary>
        /// Initializes a new instance of the MyQueueOfStrings class 
        /// that is empty and has the default initial capasity.
        /// </summary>
        public MyQueueOfStrings()
        {
            this.array = new string[0];
        }

        /// <summary>
        /// Initializes a new instance of the MyQueueOfStrings class 
        /// that is empty and has the specified initial capasity.
        /// </summary>
        /// <param name="capasity">
        /// The number of elements that the new queue can initially store.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when capasity parameter is less than 0.</exception>
        public MyQueueOfStrings(int capasity)
        {
            if (capasity < 0)
            {
                throw new ArgumentOutOfRangeException($"The queue dimension must be > 0");
            }

            this.array = new string[capasity];
            this.tail = 0;
            this.head = 0;
            this.count = 0;
        }

        /// <summary>
        /// Gets true if value of count is 0
        /// </summary>
        public bool IsEmpty => this.count == 0;

        /// <summary>
        /// Gets a value of count
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Adds new element to the queue
        /// </summary>
        /// <param name="str">Parameter represents a string element which adding to a queue</param>
        public void Enqueue(string str)
        {
            if (this.tail >= this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length + IncreaseCapasity);
            }

            this.count++;
            this.array[this.tail] = str;
            this.tail++;
        }

        /// <summary>
        /// Removes new element from the queue
        /// </summary>
        /// <returns>Returns the first element of the queue</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when queue is empty.</exception>
        public string Dequeue()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var x = this.array[this.head];
            this.array[this.head] = null;
            this.head = (this.head + 1) % this.array.Length;
            this.count--;
            return x;
        }

        /// <summary>
        /// Clears the queue
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

        /// <summary>
        /// Exposes an enumerator
        /// </summary>
        /// <returns>Returns an enumeration of strings</returns>
        public IEnumerator<string> GetEnumerator()
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
            return this.array.GetEnumerator();
        }
    }
}
