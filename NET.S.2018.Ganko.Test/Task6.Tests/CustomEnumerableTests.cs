using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Test6.Solution.SequenceGenerator;
using NUnit.Framework;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            var actual = GenerateSequence(1, 1, 10, (f, s) => (s + f));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
            var actual = GenerateSequence(1, 2, 10, (f, s) => (6 * s - 8 * f));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Generator_ForSequence3()
        {
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };
            var actual = GenerateSequence<double>(1.0, 2.0, 10, (f, s) => (s + (f / s))).ToArray();

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 0.00000000000001);
            }
        }
    }
}
