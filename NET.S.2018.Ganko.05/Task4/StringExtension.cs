using System;
using System.Text.RegularExpressions;

namespace Task4
{
    /// <summary>
    /// Class contains string extension method ToDecimalConverter
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// To the decimal converter.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="notation">The notation.</param>
        /// <returns>Returns int value.</returns>
        /// <exception cref="ArgumentException">Throw when the string does not contain the required substring."</exception>
        public static int ToDecimalConverter(this string source, Notation notation)
        {
            foreach (var item in source)
            {
                if (!Regex.IsMatch(notation.Alphabet, item.ToString(), RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException($"There is no such substring {item} in the string " 
                                                + $"{notation.Alphabet}");
                }
            }

            int result = 0;

            for (int i = 0, j = source.Length - 1; i < source.Length; i++)
            {
                checked
                {
                    result += (int)Math.Pow(notation.Basis, j - i) * notation.Alphabet.IndexOf(
                                  source[i].ToString(),
                                  StringComparison.OrdinalIgnoreCase);
                }
            }

            return result;
        }
    }
}
