using System;

namespace Task4
{
    /// <summary>
    /// Class represents notation
    /// </summary>
    public class Notation
    {
        /// <summary>
        /// The alphabet
        /// </summary>
        private const string alphabet = "0123456789ABCDEF";

        /// <summary>
        /// Initializes a new instance of the <see cref="Notation"/> class.
        /// </summary>
        /// <param name="basis">The basis of notation</param>
        /// <exception cref="ArgumentException">Throws when the basis is out of range (2; 16)</exception>
        public Notation(int basis)
        {
            if (basis < 2 || basis > 16)
            {
                throw new ArgumentException($"Invalid argument {basis}. The argument must be in (2; 16)");
            }

            Basis = basis;
        }

        /// <summary>
        /// Gets the basis.
        /// </summary>
        /// <value>
        /// The basis.
        /// </value>
        public int Basis { get; }

        /// <summary>
        /// Gets the alphabet.
        /// </summary>
        /// <value>
        /// The alphabet substring which contains elements from zero to basis.
        /// </value>
        public string Alphabet => alphabet.Substring(0, Basis);
    }
}
