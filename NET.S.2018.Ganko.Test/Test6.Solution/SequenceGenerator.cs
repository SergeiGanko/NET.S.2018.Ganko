using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public static class SequenceGenerator
    {
        public static IEnumerable<T> GenerateSequence<T>(T first, T second, int length, Func<T, T, T> rule)
        {
            CheckInput(first, second, length, rule);

            return Generate(first, second, length, rule);
        }

        private static IEnumerable<T> Generate<T>(T first, T second, int length, Func<T, T, T> rule)
        {
            yield return first;
            yield return second;

            int i = 2;

            while (i < length)
            {
                T next = rule(first, second);
                yield return next;
                first = second;
                second = next;
                i++;
            }
        }

        private static void CheckInput<T>(T first, T second, int length, Func<T, T, T> rule)
        {
            if (first == null)
            {
                throw new ArgumentNullException($"Argument {nameof(first)} is null");
            }

            if (second == null)
            {
                throw new ArgumentNullException($"Argument {nameof(first)} is null");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException($"Argument {nameof(length)} must be greater then zero");
            }

            if (rule == null)
            {
                throw new ArgumentNullException($"Argument {nameof(rule)} is null");
            }
        }
    }
}
