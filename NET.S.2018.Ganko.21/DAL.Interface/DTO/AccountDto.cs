namespace DAL.Interface.DTO
{
    /// <summary>
    /// Account Data Tranfer Object
    /// </summary>
    public class AccountDto : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the bonus.
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        public ClientDto Client { get; set; }
    }
}
