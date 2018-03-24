using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class GcdCalculatorTests
    {
        #region FindGcdByEuclidTests

        [TestCase(36, 48, ExpectedResult = 12)]
        [TestCase(48, 36, ExpectedResult = 12)]
        [TestCase(-36, 48, ExpectedResult = 12)]
        [TestCase(-36, -48, ExpectedResult = 12)]
        [TestCase(36, 0, ExpectedResult = 36)]
        [TestCase(0, 48, ExpectedResult = 48)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public int FindGcdByEuclid_PassesTwoInts_ExpectsGcdOfThwoInts(int firstNumber, int secondNumber) =>
            GcdCalculator.FindGcdByEuclid(firstNumber, secondNumber);

        [TestCase(int.MinValue, int.MaxValue)]
        public void FindGcdByEuclid_PassesTwoInts_ExpectsArgumentException(int firstNumber, int secondNumber) =>
            Assert.Throws<ArgumentException>((() => GcdCalculator.FindGcdByEuclid(firstNumber, secondNumber)));

        [TestCase(36, 48, 24, ExpectedResult = 12)]
        [TestCase(-36, 48, -24, ExpectedResult = 12)]
        [TestCase(36, -48, 24, ExpectedResult = 12)]
        [TestCase(-36, -48, -24, ExpectedResult = 12)]
        [TestCase(36, 0, 24, ExpectedResult = 12)]
        [TestCase(0, 48, 0, ExpectedResult = 48)]
        public int FindGcdByEuclid_PassesThreeInts_ExpectsGcdOfThreeInts(int firstNumber, int secondNumber, int thirdNumber) =>
            GcdCalculator.FindGcdByEuclid(firstNumber, secondNumber, thirdNumber);

        [TestCase(12, 6, int.MinValue)]
        public void FindGcdByEuclid_PassesThreeInts_ExpectsArgumentException(int firstNumber, int secondNumber, int thirdNumber) =>
            Assert.Throws<ArgumentException>((() => GcdCalculator.FindGcdByEuclid(firstNumber, secondNumber, thirdNumber)));

        [TestCase(36, 48, 26, 52, ExpectedResult = 2)]
        [TestCase(36, 48, 24, 60, ExpectedResult = 12)]
        [TestCase(0, 2, 0, 4, ExpectedResult = 2)]
        public int FindGcdByEuclid_PassesFourInts_ExpectsGcdOfFourInts(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber) =>
            GcdCalculator.FindGcdByEuclid(firstNumber, secondNumber, thirdNumber, fourthNumber);

        [TestCase(12, 6, int.MinValue, 0)]
        public void FindGcdByEuclid_PassesFourInts_ExpectsArgumentException(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber) =>
            Assert.Throws<ArgumentException>((() => GcdCalculator.FindGcdByEuclid(firstNumber, secondNumber, thirdNumber, fourthNumber)));

        [TestCase(36, 48, 24, 60, 84, 72, ExpectedResult = 12)]
        [TestCase(36, -48, 24, 60, -84, 72, ExpectedResult = 12)]
        [TestCase(36, 48, 0, 60, 84, 0, ExpectedResult = 12)]
        public int FindGcsByEuclid_PassesParamsInt_ExpectsGcd(params int[] numbers) =>
            GcdCalculator.FindGcdByEuclid(numbers);

        [TestCase(24, 48, 12, 0, int.MinValue, 36)]
        public void FindGcsByEuclid_PassesParamsInt_ExpectsArgumentException(params int[] numbers) =>
            Assert.Throws<ArgumentException>((() => GcdCalculator.FindGcdByEuclid(numbers)));

        #endregion

        #region FindGcdBySteinTests

        [TestCase(116150, 232704, ExpectedResult = 202)]
        [TestCase(0, 232704, ExpectedResult = 232704)]
        [TestCase(116150, 0, ExpectedResult = 116150)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(116150, -232704, ExpectedResult = 202)]
        [TestCase(-116150, -232704, ExpectedResult = 202)]
        public int FindGcdByStein_PassesTwoInts_ExpectsGcd(int firstNumber, int secondNumber) =>
            GcdCalculator.FindGcdByStein(firstNumber, secondNumber);

        [TestCase(202, int.MinValue)]
        public void FindGcdByStein_PassesTwoInts_ExpectsArgumentException(int firstNumber, int secondNumber) =>
            Assert.Throws<ArgumentException>(() => GcdCalculator.FindGcdByStein(firstNumber, secondNumber));

        [TestCase(116150, 232704, 404, ExpectedResult = 202)]
        public int FindGcdByStein_PassesThreeInts_ExpectsGcd(int firstNumber, int secondNumber, int thirdNumber) =>
            GcdCalculator.FindGcdByStein(firstNumber, secondNumber, thirdNumber);

        [TestCase(202, 808, int.MinValue)]
        public void FindGcdByStein_PassesThreeInts_ExpectsArgumentException(int firstNumber, int secondNumber, int thirdNumber) =>
            Assert.Throws<ArgumentException>(() => GcdCalculator.FindGcdByStein(firstNumber, secondNumber, thirdNumber));

        [TestCase(116150, 232704, 404, 808, ExpectedResult = 202)]
        public int FindGcdByStein_PassesFourInts_ExpectsGcd(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber) =>
            GcdCalculator.FindGcdByStein(firstNumber, secondNumber, thirdNumber, fourthNumber);

        [TestCase(202, int.MinValue, 808, 404)]
        public void FindGcdByStein_PassesFourInts_ExpectsArgumentException(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber) =>
            Assert.Throws<ArgumentException>(() => GcdCalculator.FindGcdByStein(firstNumber, secondNumber, thirdNumber, fourthNumber));

        [TestCase(116150, 232704, 808, 1010, 404, ExpectedResult = 202)]
        public int FindGcdByStein_PassesParamsInts_ExpectsGcd(params int[] numbers) =>
            GcdCalculator.FindGcdByStein(numbers);

        #endregion
    }
}
