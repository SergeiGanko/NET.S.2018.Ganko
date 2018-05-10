using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// The abstract class represents Bank Account
    /// </summary>
    public abstract class Account : IEquatable<Account>
    {
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

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the account number.
        /// </summary>
        public string AccountNumber { get; private set; }

        /// <summary>
        /// Gets the client.
        /// </summary>
        public Client Client { get; private set; }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Gets the bonus.
        /// </summary>
        public int Bonus { get; protected set; }

        /// <summary>
        /// Gets the account type.
        /// </summary>
        public AccountType Type { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this instance of account is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed { get; private set; }

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void Deposit(decimal amount)
        {
            CheckAmount(amount);

            Balance += amount;
            CalculateDepositBonus(amount);
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="ArgumentException">Throws when ballance is below zero</exception>
        public void Withdraw(decimal amount)
        {
            CheckAmount(amount);

            if (Balance < amount)
            {
                throw new ArgumentException($"Not enough minerals =)");
            }

            Balance -= amount;
            CalculateWithdrawBonus(amount);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// Throws when ballance not equals zero
        /// </exception>
        public void Close()
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

        #endregion

        #region Private members

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

            return string.Equals(this.AccountNumber, other.AccountNumber) 
                   && this.Client.Equals(other.Client) 
                   && this.Type == other.Type;
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

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Account)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.AccountNumber.GetHashCode();
                hashCode = (hashCode * 73) ^ this.Client.GetHashCode();
                hashCode = (hashCode * 73) ^ (int)this.Type;
                return hashCode;
            }
        }

        #endregion
    }
}
