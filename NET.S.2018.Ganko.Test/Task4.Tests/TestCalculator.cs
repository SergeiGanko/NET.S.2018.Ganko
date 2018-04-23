using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task4;
using Task4.Solution;

namespace Task4.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {
            ICalculator calculator = new MeanAverage();

            double expected = 8.3636363;

            double actual = calculator.Calculate(values);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            ICalculator calculator = new MedianAverage();

            double expected = 8.0;

            double actual = calculator.Calculate(values);

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}