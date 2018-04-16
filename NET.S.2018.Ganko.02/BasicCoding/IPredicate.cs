namespace BasicCoding
{
    public interface IPredicate<in T>
    {
        bool IsMatch(T item);
    }
}
