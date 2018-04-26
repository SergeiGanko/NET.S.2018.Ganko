using System;

namespace Task1.Solution
{
    public class MaxLengthValidator : IPasswordValidator
    {
        public Tuple<bool, string> IsValid(string password) =>
            password.Length >= 15
                       ? Tuple.Create(false, $"{password} length too long")
                       : Tuple.Create(true, $"{password} is valid");
    }
}
