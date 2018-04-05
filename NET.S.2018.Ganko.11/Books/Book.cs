using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Books
{
    /// <summary>
    /// Book class
    /// </summary>
    /// <seealso cref="System.IComparable"/>
    /// <seealso cref="System.IComparable{Books.Book}"/>
    /// <seealso cref="System.IEquatable{Books.Book}"/>
    /// <seealso cref="System.IFormattable" />
    public sealed class Book : IComparable, IComparable<Book>, IEquatable<Book>, IFormattable
    {
        private const string isbnPattern =
            @"^(?:ISBN(?:-13)?:?\)?(?=[0-9]{13}$|(?=(?:[0-9]+[-\]){4})[-\0-9]{17}$)97[89][-\]?[0-9]{1,5}[-\]?[0-9]+[-\]?[0-9]+[-\]?[0-9]$";

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        /// <param name="author">The author.</param>
        /// <param name="title">The title.</param>
        /// <param name="publisher">The publicher.</param>
        /// <param name="year">The publishing year.</param>
        /// <param name="pages">The number of pages.</param>
        /// <param name="price">The price.</param>
        public Book(string isbn, string author, string title, string publisher, int year, int pages, decimal price)
        {
            ValidateInput(isbn, author, title, publisher, year, pages, price);

            Isbn = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            PublishingYear = year;
            PagesNumber = pages;
            Price = price;
        }

        #region Public properties

        /// <summary>
        /// Gets the isbn.
        /// </summary>
        public string Isbn { get; }

        /// <summary>
        /// Gets the author.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the publisher.
        /// </summary>
        public string Publisher { get; }

        /// <summary>
        /// Gets the publishing year.
        /// </summary>
        public int PublishingYear { get; }

        /// <summary>
        /// Gets the pages number.
        /// </summary>
        public int PagesNumber { get; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public decimal Price { get; }

        #endregion

        #region System.Object methods overriding

        /// <summary>
        /// Determines whether the specified <see cref="Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Book book && this.Equals(book);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Isbn.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string format = "G";
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        #endregion

        #region IEquatable<T> implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Isbn == other.Isbn;
        }

        #endregion

        #region IComparable implementation

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="InvalidOperationException">Throws when the obj isn't a Book</exception>
        public int CompareTo(object obj)
        {
            if (!(obj is Book))
            {
                throw new InvalidOperationException($"{nameof(obj)} is not a Book");
            }

            return this.CompareTo((Book)obj);
        }

        #endregion

        #region IComparable<T> implementation

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (Equals(other))
            {
                return 0;
            }

            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return string.Compare(this.Title, other.Title, StringComparison.Ordinal);
        }

        #endregion

        #region IFormattable implementation

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">Throws when format is invalid</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "AT":
                    return $"{Author}, {Title}";
                case "ATPY":
                    return $"{Author}, {Title}, \"{Publisher}\", {PublishingYear}";
                case "G":
                case "IATPYN":
                    return $"ISBN 13: {Isbn}, {Author}, {Title}, \"{Publisher}\", {PublishingYear}, {PagesNumber}";
                case "IATPYNP":
                    return $"ISBN 13: {Isbn}, {Author}, {Title}, \"{Publisher}\", {PublishingYear}, {PagesNumber}, {Price.ToString("C", formatProvider)}";
                default:
                    throw new FormatException($"Invalid argument {nameof(format)}");
            }
        }

        #endregion

        #region Overload version of ToString()

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        #endregion

        #region ctor validation

        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        /// <param name="author">The author.</param>
        /// <param name="title">The title.</param>
        /// <param name="publicher">The publicher.</param>
        /// <param name="year">The year.</param>
        /// <param name="pages">The pages.</param>
        /// <param name="price">The price.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void ValidateInput(string isbn, string author, string title, string publicher, int year, int pages, decimal price)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException($"Invalid argument {nameof(isbn)}");
            }

            if (!Regex.IsMatch(isbn, isbnPattern))
            {
                throw new ArgumentException($"Invalid format of ISBN");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException($"Invalid argument {nameof(author)}");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"Invalid argument {nameof(title)}");
            }

            if (string.IsNullOrWhiteSpace(publicher))
            {
                throw new ArgumentException($"Invalid argument {nameof(publicher)}");
            }

            if (year < 1701 && year > DateTime.Today.Year)
            {
                throw new ArgumentOutOfRangeException($"Invalid publishing year");
            }

            if (pages < 0)
            {
                throw new ArgumentException($"Invalid number of pages");
            }

            if (price < 0)
            {
                throw new ArgumentException($"Invalid book price");
            }
        }

        #endregion
    }
}
