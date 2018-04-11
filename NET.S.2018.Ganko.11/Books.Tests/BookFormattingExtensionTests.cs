using BookFormattingExtension;
using NUnit.Framework;

namespace Books.Tests
{
    using System;

    [TestFixture]
    class BookFormattingExtensionTests
    {
        private static readonly Book book = new Book(
            "978-0-672-33690-4",
            "Bart De Smet",
            "C# 5.0 Unleashed",
            "SAMS Publishing",
            2013,
            1671,
            51.29m);

        [TestCase("{0:tp}", ExpectedResult = "C# 5.0 Unleashed, 51,29р.")]
        [TestCase("{0:TP}", ExpectedResult = "C# 5.0 Unleashed, 51,29р.")]
        public string FormatTest(string format)
        {
            return string.Format(new BookFormatProvider(), format, book);
        }

        [TestCase("{0:qq}")]
        public void Format_FormatExceptionExpected(string format)
        {
            Assert.Throws<FormatException>(() => string.Format(new BookFormatProvider(), format, book));
        }
    }
}
