using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public class MeanAverage : ICalculator
    {
        public double Calculate(IEnumerable<double> collection)
        {
            return collection.Sum() / collection.Count();
        }
    }
}
