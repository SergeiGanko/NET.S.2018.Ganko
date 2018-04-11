using System;
using NUnit.Framework;
using System.Collections;
using System.Globalization;

namespace Books.Tests
{
    [TestFixture]
    public class BookTests
    {
        private static readonly Book book = new Book(
            "978-0-672-33690-4",
            "Bart De Smet",
            "C# 5.0 Unleashed",
            "SAMS Publishing",
            2013,
            1671,
            51.29m);

        public static IEnumerable ToStringTestCases
        {
            get
            {
                yield return new TestCaseData("AT", null)
                    .Returns("Bart De Smet, C# 5.0 Unleashed");
                yield return new TestCaseData("at", null)
                    .Returns("Bart De Smet, C# 5.0 Unleashed");
                yield return new TestCaseData("ATPY", null)
                    .Returns("Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013");
                yield return new TestCaseData("atpY", null)
                    .Returns("Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013");
                yield return new TestCaseData("IATPYN", null)
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671");
                yield return new TestCaseData("iatpyn", null)
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671");
                yield return new TestCaseData(string.Empty, null)
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671, 51,29р.");
                yield return new TestCaseData("G", null)
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671, 51,29р.");
                yield return new TestCaseData("g", null)
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671, 51,29р.");
                yield return new TestCaseData(null, null)
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671, 51,29р.");
                yield return new TestCaseData("IATPYNP", new CultureInfo("en-Us"))
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671, $51.29");
                yield return new TestCaseData("iatpynp", null)
                    .Returns("ISBN 13: 978-0-672-33690-4, Bart De Smet, C# 5.0 Unleashed, \"SAMS Publishing\", 2013, 1671, 51,29р.");
            }
        }

        public static IEnumerable ToStringExceptionsTestCases
        {
            get
            {
                yield return new TestCaseData("qw", null);
                yield return new TestCaseData("f", CultureInfo.InvariantCulture);
            }
        }

        [Test, TestCaseSource(nameof(ToStringTestCases))]
        public string ToString_PositiveTestCases(string format, IFormatProvider provider)
        {
            return book.ToString(format, provider);
        }

        [Test, TestCaseSource(nameof(ToStringExceptionsTestCases))]
        public void ToString_FormatExceptionExpected(string format, IFormatProvider provider)
        {
            Assert.Throws<FormatException>(() => book.ToString(format, provider));
        }

    }
}
