namespace BasicCoding.NUnitTests
{
    public class NegativeNumber : IPredicate
    {
        public bool IsMatch(int number)
        {
            return number < 0;
        }
    }
}
