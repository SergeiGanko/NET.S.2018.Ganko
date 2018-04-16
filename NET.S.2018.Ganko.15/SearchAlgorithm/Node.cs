using System;

namespace SearchAlgorithm
{
    /// <summary>
    /// Class Node<typeparam name="T"></typeparam>
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public sealed class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Throw when the value is null</exception>
        public Node(T value)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException($"Argument {nameof(value)} is null");
            }

            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        public Node<T> Right { get; set; }
    }
}
