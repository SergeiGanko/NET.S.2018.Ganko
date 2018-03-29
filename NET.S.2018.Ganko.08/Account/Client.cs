namespace Account
{
    /// <summary>
    /// Class represents bank client's account info
    /// </summary>
    public sealed class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string LastName { get; }
    }
}
