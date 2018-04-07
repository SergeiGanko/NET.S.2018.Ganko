using System;

namespace Books.CustomException
{
    public class BookAlreadyExistException : Exception
    {
        public BookAlreadyExistException()
        {
        }

        public BookAlreadyExistException(string message) : base(message)
        {
        }

        public BookAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
