using System;
using System.Collections.Generic;

namespace BasicCoding
{
    using System.Diagnostics;

    /// <summary>
    /// WorkingWithNumbers class
    /// </summary>
    public static class WorkingWithNumbers
    {
        #region FilterDigit methods

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
                throw new ArgumentNullException($"{nameof(input)} is null or empty");
            }

            if (input.Length == 0)
            {
                throw new ArgumentException($"{nameof(input)} is empty");
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"Invalid argument - {nameof(digit)}");
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

            while (number > 0 || number < 0)
            {
                if (number % 10 == digit || number % 10 == -digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        #endregion

        #region FindNextBiggerNumber methods

        /// <summary>
        /// Finds the next bigger number than <paramref name="number"/>, which consists of its digits.
        /// </summary>
        /// <param name="number">Positive number</param>
        /// <returns>Returns the next bigger number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception when argument less than 1</exception>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException($"Argument {nameof(number)} must be greater than 0.");
            }

            List<int> listOfDigits = new List<int>();

            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                listOfDigits.Add(digit);
            }

            int j = 0;
            int i = j + 1;

            if (listOfDigits.Count > 1)
            {
                while (i < listOfDigits.Count)
                {
                    if (listOfDigits[i] < listOfDigits[j])
                    {
                        break;
                    }

                    i++;
                    j++;
                }

                if (i >= listOfDigits.Count)
                {
                    return -1;
                }

                j = 0;

                while (j < i)
                {
                    if (listOfDigits[j] > listOfDigits[i])
                    {
                        break;
                    }

                    j++;
                }

                int temp = listOfDigits[i];
                listOfDigits[i] = listOfDigits[j];
                listOfDigits[j] = temp;
            }
            else
            {
                return -1;
            }

            List<int> subList = listOfDigits.GetRange(0, i);

            if (subList.Count > 1)
            {
                subList.Sort();
            }

            int m = listOfDigits.Count - 1;
            int nextBiggerNumber = 0;

            while (m >= i)
            {
                nextBiggerNumber = (nextBiggerNumber * 10) + listOfDigits[m];
                m--;
            }

            m = 0;
            while (m < subList.Count)
            {
                nextBiggerNumber = (nextBiggerNumber * 10) + subList[m];
                m++;
            }

            return nextBiggerNumber;
        }

        /// <summary>
        /// Finds the next bigger number than <paramref name="number"/>, which consists of its digits.
        /// Also defines method working time.
        /// </summary>
        /// <param name="number">Positive number.</param>
        /// <returns>Returns tuple of int and long.</returns>
        public static (int, double) FindNextBiggerNumberAndTimeOfWorking(int number)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int nextBiggerNumber = FindNextBiggerNumber(number);
            stopwatch.Stop();

            double milliseconds = stopwatch.Elapsed.TotalMilliseconds;

            var result = (nextBiggerNumber, milliseconds);
            return result;
        }

        /// <summary>
        /// Finds the next bigger number than <paramref name="number"/>, which consists of its digits.
        /// Also defines method working time.
        /// </summary>
        /// <param name="number">Positive number.</param>
        /// <param name="milliseconds">The out parameter which represents method working time in milliseconds.</param>
        /// <returns></returns>
        public static int FindNextBiggerNumberAndTimeOfWorking(int number, out double milliseconds)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int nextBiggerNumber = FindNextBiggerNumber(number);
            stopwatch.Stop();
            milliseconds = stopwatch.ElapsedMilliseconds;

            return nextBiggerNumber;
        }

        #endregion
    }
}
