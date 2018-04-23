using System.Collections.Generic;

namespace Task4.Solution
{
    public interface ICalculator
    {
        double Calculate(IEnumerable<double> collection);
    }
}
