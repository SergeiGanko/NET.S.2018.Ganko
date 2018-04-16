namespace BasicCoding.NUnitTests
{
    public class EvenNumber : IPredicate<int>
    {
        public bool IsMatch(int number)
        {
            return number % 2 == 0;
        }
    }
}
