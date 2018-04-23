using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public static class Calculator
    {
        public static double CalculateAverage(IEnumerable<double> values, ICalculator calculator)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"Argument {nameof(values)} is null");
            }

            if (!values.Any())
            {
                throw new ArgumentException($"Argument {nameof(values)} is empty collection");
            }

            return calculator.Calculate(values);
        }

        public static double CalculateAverage(IEnumerable<double> values, Func<IEnumerable<double>, double> method)
        {
            return method(values);
        }
    }
}
