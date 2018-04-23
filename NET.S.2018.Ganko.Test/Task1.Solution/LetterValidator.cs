using System;
using System.Linq;

namespace Task1.Solution
{
    public class LetterValidator : IPasswordValidator
    {
        public Tuple<bool, string> IsValid(string password) =>
            password.Any(char.IsLetter)
                       ? Tuple.Create(true, $"{password} is valid")
                       : Tuple.Create(false, $"{password} hasn't alphanumerical chars");
    }
}
