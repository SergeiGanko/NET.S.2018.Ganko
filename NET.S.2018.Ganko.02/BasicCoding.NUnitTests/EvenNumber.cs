namespace BasicCoding.NUnitTests
{
    public class EvenNumber : IPredicate
    {
        public bool IsMatch(int number)
        {
            return number % 2 == 0;
        }
    }
}
