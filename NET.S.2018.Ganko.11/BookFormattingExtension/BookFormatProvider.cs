using System;
using System.Globalization;
using Books;

namespace BookFormattingExtension
{
    public sealed class BookFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        public BookFormatProvider() : this(CultureInfo.CurrentCulture)
        {
        }

        public BookFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(Book))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of {nameof(format)} is invalid.\n{e.Message}");
                }
            }

            Book book = arg as Book;

            if (ReferenceEquals(book, null))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of {nameof(format)} is invalid.\n{e.Message}");
                }
            }

            switch (format.ToUpperInvariant())
            {
                case "TP":
                    {
                        return $"{book.Title}, {book.Price.ToString("C", formatProvider)}";
                    }

                default:
                    {
                        try
                        {
                            return HandleOtherFormats(format, arg);
                        }
                        catch (FormatException e)
                        {
                            throw new FormatException($"The format of {nameof(format)} is invalid.\n{e.Message}");
                        }
                    }
            }
        }

        private static string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }

            if (arg != null)
            {
                return arg.ToString();
            }

            return string.Empty;
        }
    }
}
