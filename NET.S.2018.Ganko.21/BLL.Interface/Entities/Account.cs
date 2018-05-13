using System;

namespace BLL.Interface.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The abstract class represents Bank Account
    /// </summary>
    public abstract class Account : IEquatable<Account>
    {
        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        internal Account()
        {
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the account number.
        /// </summary>
        public string AccountNumber { get; internal set; }

        /// <summary>
        /// Gets the client.
        /// </summary>
        public Client Client { get; internal set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        public decimal Balance { get; protected internal set; }

        /// <summary>
        /// Gets or sets the bonus.
        /// </summary>
        public int Bonus { get; protected internal set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public AccountType Type { get; protected internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed { get; protected internal set; }

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

            WithdrawMoney(amount);
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

        #endregion

        #region Protected Members

        /// <summary>
        /// Gets or sets the deposit value.
        /// </summary>
        protected int DepositValue { get; set; }

        /// <summary>
        /// Gets or sets the balance value.
        /// </summary>
        protected int BalanceValue { get; set; }

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

        /// <summary>
        /// Withdraws the money. By default, balance must not be negative.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="ArgumentException">Throws when balance is below zero</exception>
        protected virtual void WithdrawMoney(decimal amount)
        {
            if (Balance < amount)
            {
                throw new ArgumentException($"Not enough money");
            }

            Balance -= amount;

            CalculateWithdrawBonus(amount);
        }

        /// <summary>
        /// Ckecks the input.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        /// <param name="bonus">The bonus.</param>
        /// <exception cref="System.ArgumentException">Throws when accountNumber is null, empty or whitespace</exception>
        /// <exception cref="System.ArgumentNullException">Throws when client is null</exception>
        protected void CkeckInput(string accountNumber, Client client)
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

        #endregion

        #region Private members

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
            unchecked
            {
                var hashCode = this.AccountNumber.GetHashCode();
                hashCode = (hashCode * 73) ^ this.Client.FirstName.GetHashCode();
                hashCode = (hashCode * 73) ^ this.Client.LastName.GetHashCode();
                hashCode = (hashCode * 73) ^ this.Client.PassportNumber.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
