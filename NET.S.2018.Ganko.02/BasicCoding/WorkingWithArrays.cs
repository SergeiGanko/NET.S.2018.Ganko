using System;
using System.Collections.Generic;

namespace BasicCoding
{
    /// <summary>
    /// WorkingWithArrays class
    /// </summary>
    public static class WorkingWithArrays
    {
        /// <summary>
        /// Method filtering elements of array which contain a specific digit
        /// </summary>
        /// <param name="input">Input array of ints</param>
        /// <param name="digit">input digit(0-9)</param>
        /// <returns>Returns filtered array</returns>
        public static int[] FilterDigit(int[] input, int digit)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"Input is null");
            }

            if (input.Length == 0 || digit < 0 || digit > 9)
            {
                throw new ArgumentException("Invalid argument(s)");
            }

            var temp = new List<int>();

            foreach (var i in input)
            {
                if (IsDigitContains(i, digit))
                {
                    temp.Add(i);
                }
            }

            return temp.ToArray();
        }

        /// <summary>
        /// This method searches for the occurrence of a specific digit in a number
        /// </summary>
        /// <param name="number">Represents element of array</param>
        /// <param name="digit">Represents a specific digit</param>
        /// <returns>Returns true if number contains digit</returns>
        private static bool IsDigitContains(int number, int digit)
        {
            if (number == digit)
            {
                return true;
            }

            if (number < 0)
            {
                number = Math.Abs(number);
            }

            while (number > 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
