namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class represents bank client's account info
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public Client(string firstName, string lastName, string passportNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
            Email = email;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the passport.
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
    }
}
