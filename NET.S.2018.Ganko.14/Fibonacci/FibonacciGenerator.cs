using System;
using System.Collections.Generic;
using System.Numerics;

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
        public static IEnumerable<BigInteger> Generate(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException($"Argument {nameof(length)} must be greater the zero");
            }

            return Generator(length);
        }

        /// <summary>
        /// Generates the Fibonacci sequence.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>Returns Fibonacci sequence</returns>
        private static IEnumerable<BigInteger> Generator(int length)
        {
            BigInteger first = 1;
            BigInteger second = 1;

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
                BigInteger number = first + second;
                yield return number = first + second;
                first = second;
                second = number;
                i++;
            }
        }
    }
}
