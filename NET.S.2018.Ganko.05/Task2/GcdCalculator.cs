using System;

namespace Task2
{
    /// <summary>
    /// Class encapsulates GCD calculation methods
    /// </summary>
    public static class GcdCalculator
    {
        #region FindGcdByEuclid

        /// <summary>
        /// Finds the GCD by euclid.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>Returns GCD of two numbers</returns>
        /// <exception cref="ArgumentException">Throws when argument value is int.MinValue</exception>
        public static int FindGcdByEuclid(int firstNumber, int secondNumber)
        {
            if (firstNumber == int.MinValue || secondNumber == int.MinValue)
            {
                throw new ArgumentException($"Can't be calculated, because |{int.MinValue}| is out of range of int");
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber < 0)
            {
                firstNumber = Math.Abs(firstNumber);
            }

            if (secondNumber < 0)
            {
                secondNumber = Math.Abs(secondNumber);
            }

            while (secondNumber != 0)
            {
                firstNumber %= secondNumber;
                Swap(ref firstNumber, ref secondNumber);
            }

            return firstNumber;
        }

        /// <summary>
        /// Finds the GCD by euclid.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>Returns GCD of three numbers</returns>
        public static int FindGcdByEuclid(int firstNumber, int secondNumber, int thirdNumber)
        {
            return FindGcdByEuclid(FindGcdByEuclid(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Finds the GCD by euclid.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <param name="fourthNumber">The fourth number.</param>
        /// <returns>Returns GCD of four numbers</returns>
        public static int FindGcdByEuclid(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            int gcdOfFirstAndSecond = FindGcdByEuclid(firstNumber, secondNumber);
            int gcdOfThirdAndFourth = FindGcdByEuclid(thirdNumber, fourthNumber);
            return FindGcdByEuclid(gcdOfFirstAndSecond, gcdOfThirdAndFourth);
        }

        /// <summary>
        /// Finds the GCD by euclid.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of numbers</returns>
        public static int FindGcdByEuclid(params int[] numbers)
        {
            int gcd = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                gcd = FindGcdByEuclid(gcd, numbers[i]);
            }

            return gcd;
        }

        #endregion

        #region FindGcdByStein

        /// <summary>
        /// Finds the GCD by stein.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>Returns GCD of two numbers</returns>
        /// <exception cref="ArgumentException">Throws when argument value is int.MinValue</exception>
        public static int FindGcdByStein(int firstNumber, int secondNumber)
        {
            if (firstNumber == int.MinValue || secondNumber == int.MinValue)
            {
                throw new ArgumentException($"Can't be calculated, because |{int.MinValue}| is out of int range");
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber < 0)
            {
                firstNumber = Math.Abs(firstNumber);
            }

            if (secondNumber < 0)
            {
                secondNumber = Math.Abs(secondNumber);
            }

            bool isFirstNumberEven = (firstNumber & 1) == 0;
            bool isSecondNumberEven = (secondNumber & 1) == 0;

            if (isFirstNumberEven && isSecondNumberEven)
            {
                return FindGcdByStein(firstNumber >> 1, secondNumber >> 1) << 1;
            }

            if (isFirstNumberEven && !isSecondNumberEven)
            {
                return FindGcdByStein(firstNumber >> 1, secondNumber);
            }

            if (isSecondNumberEven)
            {
                return FindGcdByStein(firstNumber, secondNumber >> 1);
            }

            if (firstNumber > secondNumber)
            {
                return FindGcdByEuclid((firstNumber - secondNumber) >> 1, secondNumber);
            }

            return FindGcdByStein(firstNumber, (secondNumber - firstNumber) >> 1);
        }

        /// <summary>
        /// Finds the GCD by stein.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>Returns GCD of three numbers</returns>
        public static int FindGcdByStein(int firstNumber, int secondNumber, int thirdNumber)
        {
            return FindGcdByStein(FindGcdByStein(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Finds the GCD by stein.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <param name="fourthNumber">The fourth number.</param>
        /// <returns>Returns GCD of four numbers</returns>
        public static int FindGcdByStein(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            return FindGcdByStein(FindGcdByStein(firstNumber, secondNumber), FindGcdByStein(thirdNumber, fourthNumber));
        }

        /// <summary>
        /// Finds the GCD by stein.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Returns GCD of numbers</returns>
        public static int FindGcdByStein(params int[] numbers)
        {
            int gcd = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                gcd = FindGcdByStein(gcd, numbers[i]);
            }

            return gcd;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Swaps two numbers.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = secondNumber;
            secondNumber = firstNumber;
            firstNumber = temp;
        }

        #endregion
    }
}
