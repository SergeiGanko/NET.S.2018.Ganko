using System;
using BLL.Interface.Interfaces;

namespace BLL.Services
{
    /// <summary>
    /// AccountNumberGenerator class
    /// </summary>
    /// <seealso cref="IAccountNumberCreateSevice" />
    public class AccountNumberCreateSevice : IAccountNumberCreateSevice
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Generates account number as an IBAN string.
        /// </summary>
        /// <returns>Returns account number</returns>
        public string Generate()
        {
            string countryCode = "BY";

            string controlNumber = GetRandomInteger(10, 99).ToString();

            string bankCode = new string(GetRandomCharacters(4));

            string balanceAccount = GetRandomInteger(1000, 9999).ToString();

            string IndividualAccount = GetRandomInteger(10000000, 99999999).ToString()
                                       + GetRandomInteger(10000000, 99999999).ToString();

            return countryCode + controlNumber + bankCode + balanceAccount + IndividualAccount;
        }

        /// <summary>
        /// Gets the random integer.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>Returns random integer</returns>
        private static int GetRandomInteger(int min, int max)
        {
            return random.Next(min, max);
        }

        /// <summary>
        /// Gets the random characters.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>Returns array of random chars</returns>
        public static char[] GetRandomCharacters(int quantity)
        {
            var letters = new char[quantity];

            for (int i = 0; i < quantity; i++)
            {
                letters[i] = (char)random.Next(65, 90);
            }

            return letters;
        }
    }
}
