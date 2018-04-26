using System;

namespace Task1.Solution
{
    public class MinLengthValidator : IPasswordValidator
    {
        public Tuple<bool, string> IsValid(string password) =>
            password.Length <= 7
                       ? Tuple.Create(false, $"{password} length too short")
                       : Tuple.Create(true, $"{password} is valid");
    }
}
