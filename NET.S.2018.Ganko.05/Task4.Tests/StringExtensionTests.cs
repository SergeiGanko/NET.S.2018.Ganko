using NUnit.Framework;
using System;

namespace Task4.Tests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("11101101111011001100001010", 2, 62370570)]
        [TestCase("1AeF101", 16, 28242177)]
        [TestCase("1ACB67", 16, 1756007)]
        [TestCase("764241", 8, 256161)]
        [TestCase("10", 5, 5)]
        public void ToDecimalConverter_PassesString_ExpectsInt(string source, int basis, int expectedResult)
        {
            int actualResult = source.ToDecimalConverter(new Notation(basis));
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("SA123", 2)]
        [TestCase("1AeF101", 2)]
        [TestCase("764241", 20)]
        public void ToDecimalConverter_PassesInvalidString_ExpectsArgumentException(string source, int basis)
        {
            Assert.Throws<ArgumentException>(() => source.ToDecimalConverter(new Notation(basis)));
        }

        [TestCase("11111111111111111111111111111111", 2)]
        public void ToDecimalConverter_PassesInvalidString_ExpectsOverflowException(string source, int basis)
        {
            Assert.Throws<OverflowException>(() => source.ToDecimalConverter(new Notation(basis)));
        }
    }
}
