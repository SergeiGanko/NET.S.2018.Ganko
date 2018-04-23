using System;

namespace Task1.Solution
{
    public interface IPasswordValidator
    {
        Tuple<bool, string> IsValid(string password);
    }
}
