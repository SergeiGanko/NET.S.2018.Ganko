using System.Collections;
using NUnit.Framework;

namespace BasicCoding.NUnitTests
{
    public class DataForTests
    {
        public static IEnumerable FilerDigitTestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { -1, -53, -12412312, -555, -2137 }, 3)
                    .Returns(new int[] { -53, -12412312, -2137 });
                yield return new TestCaseData(new int[] { int.MaxValue, -1, 0, 535, -2, -7341451, int.MinValue }, 3)
                    .Returns(new int[] { int.MaxValue, 535, -7341451, int.MinValue });
                yield return new TestCaseData(new int[] { 0, 1, 0, 1, 0, 0 }, 0)
                    .Returns(new int[] { 0, 0, 0, 0 });
            }
        }
    }
}