using System;

namespace Task1.Solution
{
    public class EmptinessValidator : IPasswordValidator
    {
        public Tuple<bool, string> IsValid(string password) => 
            password == string.Empty
                       ? Tuple.Create(false, $"{password} is empty")
                       : Tuple.Create(true, $"{password} is valid");
    }
}
