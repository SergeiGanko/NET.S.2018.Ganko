using System;
using System.Linq;

namespace Task1.Solution
{
    public class DigitValidator : IPasswordValidator
    {
        public Tuple<bool, string> IsValid(string password) =>
            password.Any(char.IsNumber)
                       ? Tuple.Create(true, $"{password} is valid")
                       : Tuple.Create(false, $"{password} hasn't digits");
    }
}
