namespace BasicCoding.NUnitTests
{
    public class NegativeNumber : IPredicate<int>
    {
        public bool IsMatch(int number)
        {
            return number < 0;
        }
    }
}
