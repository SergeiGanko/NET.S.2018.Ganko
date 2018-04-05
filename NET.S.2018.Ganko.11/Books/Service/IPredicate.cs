namespace Books.Service
{
    public interface IPredicate
    {
        bool isMatch(Book book);
    }
}
