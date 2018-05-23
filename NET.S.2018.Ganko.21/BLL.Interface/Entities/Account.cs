using System;

namespace BLL.Interface.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The abstract class represents Bank Account
    /// </summary>
    public abstract class Account : IEquatable<Account>
    {
        /// <summary>
        /// The account balance
        /// </summary>
        protected decimal balance;

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        protected Account(string accountNumber, Client client)
        {
            CkeckInput(accountNumber, client);

            AccountNumber = accountNumber;
            Client = client;
            IsClosed = false;
        }

        protected Account(string accountNumber, Client client, decimal balance, int bonus, bool isClosed)
        {
            AccountNumber = accountNumber;
            Client = client;
            Balance = balance;
            Bonus = bonus;
            IsClosed = isClosed;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        public string AccountNumber { get; protected set; }

        /// <summary>
        /// Gets the client.
        /// </summary>
        public Client Client { get; protected set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        public abstract decimal Balance { get; protected set; }

        /// <summary>
        /// Gets or sets the bonus.
        /// </summary>
        public int Bonus { get; protected set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public AccountType Type { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed { get; protected set; }

        /// <summary>
        /// Gets or sets the deposit value.
        /// </summary>
        protected int DepositValue { get; set; }

        /// <summary>
        /// Gets or sets the balance value.
        /// </summary>
        protected int BalanceValue { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        internal void Deposit(decimal amount)
        {
            CheckAmount(amount);

            Balance += amount;
            CalculateDepositBonus(amount);
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        internal void Withdraw(decimal amount)
        {
            CheckAmount(amount);

            Balance -= amount;
            CalculateWithdrawBonus(amount);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// Throws when ballance not equals zero
        /// </exception>
        internal void Close()
        {
            if (Balance < 0)
            {
                throw new InvalidOperationException($"Account can't be closed. Unpaid debt: {Balance}.");
            }

            if (Balance > 0)
            {
                throw new InvalidOperationException($"Account can't be closed. Balance: {Balance}.");
            }

            if (Balance == 0)
            {
                Bonus = 0;
                IsClosed = true;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"| {this.AccountNumber} | {Type} | {Client.FirstName + Client.LastName} | {Balance} | {Bonus} |";
        }

        /// <summary>
        /// Calculates the deposit bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected abstract void CalculateDepositBonus(decimal amount);

        /// <summary>
        /// Calculates the withdraw bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected abstract void CalculateWithdrawBonus(decimal amount);

        #endregion

        #region Private methods

        /// <summary>
        /// Ckecks the input.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        /// <param name="bonus">The bonus.</param>
        /// <exception cref="System.ArgumentException">Throws when accountNumber is null, empty or whitespace</exception>
        /// <exception cref="System.ArgumentNullException">Throws when client is null</exception>
        private void CkeckInput(string accountNumber, Client client)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentException($"Argument {nameof(accountNumber)} is null, empty or whitespace");
            }

            if (client == null)
            {
                throw new ArgumentNullException($"Argument {nameof(client)} is null");
            }
        }

        /// <summary>
        /// Checks the amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="System.ArgumentException">Throws when the amount is below or equals zero</exception>
        private void CheckAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Amount must be greater than zero");
            }
        }

        #endregion

        #region IEquatable<Account> members implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Account other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.AccountNumber, other.AccountNumber);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
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

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Account)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.AccountNumber.GetHashCode() ^ this.Type.GetHashCode();
        }

        #endregion
    }
}
