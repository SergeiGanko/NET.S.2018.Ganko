using System;

namespace BasicCoding.NUnitTests
{
    public class ContainDigit : IPredicate<int>
    {
        public ContainDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"Invalid argument {nameof(digit)}");
            }

            Digit = digit;
        }

        public int Digit { get; }

        public bool IsMatch(int number)
        {
            if (number == Digit)
            {
                return true;
            }

            while (number > 0 || number < 0)
            {
                if (number % 10 == Digit || number % 10 == -Digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
