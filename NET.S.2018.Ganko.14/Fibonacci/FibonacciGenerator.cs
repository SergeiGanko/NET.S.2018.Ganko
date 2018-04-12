using System;
using System.Collections.Generic;

namespace Fibonacci
{
    /// <summary>
    /// Class FibonacciGenerator
    /// </summary>
    public static class FibonacciGenerator
    {
        /// <summary>
        /// Generates the Fibonacci sequence.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>Returns Fibonacci sequence</returns>
        /// <exception cref="System.ArgumentException">Throws when the length less than zero</exception>
        public static IEnumerable<long> Generate(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException($"Argument {nameof(length)} must be greater the zero");
            }

            long first = 1;
            long second = 1;

            if (length == 1)
            {
                yield return first;
                yield break;
            }

            yield return first;
            yield return second;

            long i = 2;

            while (i < length)
            {
                long number = first + second;
                yield return number = first + second;
                first = second;
                second = number;
                i++;
            }

        }
    }
}
