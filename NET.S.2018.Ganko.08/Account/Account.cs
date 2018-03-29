using System;

namespace Account
{
    /// <summary>
    /// The abstract class represents Bank Account
    /// </summary>
    public abstract class Account
    {
        private static int counter = 0;

        private int id;

        private Client client;

        private decimal balance;

        protected double bonus = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="balance">The balance.</param>
        /// <exception cref="ArgumentException">Throws when firstName or lastName is null or whitespace</exception>
        protected Account(string firstName, string lastName, decimal balance)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"Error! Inconsistent {nameof(firstName)} or {nameof(lastName)}");
            }

            id = ++counter;
            client = new Client(firstName, lastName);
            this.balance = balance;
        }

        public int Id => id;

        public decimal Balance => balance;

        protected AccountType Type { get; set; }

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public virtual void Deposit(decimal amount)
        {
            balance += amount;
            CalculateDepositBonus(amount);
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="ArgumentException"></exception>
        public virtual void Withdraw(decimal amount)
        {
            if (balance < amount)
            {
                throw new ArgumentException($"Not enough minerals =)");
            }

            balance -= amount;
            CalculateWithdrawBonus(amount);
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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"| {id} | {Type} | {client.FirstName + client.LastName} | {Balance} | {bonus} |";
        }
    }
}
