using System;

namespace BLL.Interface.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Class represents bank client's account info
    /// </summary>
    public class Client : IEquatable<Client>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        {
        }

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
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

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

        #region IEquatable Implementation

        public bool Equals(Client other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id == other.Id 
                   && string.Equals(this.PassportNumber, other.PassportNumber) 
                   && string.Equals(this.Email, other.Email);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() 
                   && this.Equals((Client)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.Id;
                hashCode = (hashCode * 397) ^ this.PassportNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Email.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
