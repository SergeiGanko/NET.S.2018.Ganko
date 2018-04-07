namespace Books.Service
{
    public interface IPredicate<T>
    {
        bool isMatch(T t);
    }
}
