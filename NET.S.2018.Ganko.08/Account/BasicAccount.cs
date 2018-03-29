using System;

namespace Account
{
    /// <summary>
    /// The BasicAccount class
    /// </summary>
    /// <seealso cref="Account" />
    public sealed class BasicAccount : Account
    {
        private const int depositValue = 1;
        private const int balanceValue = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAccount"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="balance">The balance.</param>
        public BasicAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        {
            Type = AccountType.Basic;
        }

        /// <summary>
        /// Calculates the deposit bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateDepositBonus(decimal amount)
        {
            this.bonus += Convert.ToDouble((amount * depositValue) / 100m);
        }

        /// <summary>
        /// Calculates the withdraw bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateWithdrawBonus(decimal amount)
        {
            this.bonus -= Convert.ToDouble((amount * balanceValue) / 100m);
        }
    }
}
