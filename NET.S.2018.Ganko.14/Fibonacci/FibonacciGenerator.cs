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
        /// <returns>Returns Fibonacci sequence until length</returns>
        /// <exception cref="System.ArgumentException">Throws when the length less than zero</exception>
        public static IEnumerable<BigInteger> GenerateFibonacci(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException($"Argument {nameof(length)} must be greater the zero");
            }

            return Generate(length);
        }

        /// <summary>
        /// Generates the Fibonacci sequence.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>Returns Fibonacci sequence until length</returns>
        private static IEnumerable<BigInteger> Generate(int length)
        {
            BigInteger first = BigInteger.One;
            BigInteger second = BigInteger.One;

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
                var number = first + second;
                yield return number;
                first = second;
                second = number;
                i++;
            }
        }
    }
}
