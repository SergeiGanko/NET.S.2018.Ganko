using System;

namespace Account
{
    /// <summary>
    /// The SilverAccount class
    /// </summary>
    /// <seealso cref="Account" />
    public sealed class SilverAccount : Account
    {
        private const int depositValue = 3;
        private const int balanceValue = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="SilverAccount"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="balance">The balance.</param>
        public SilverAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        {
            Type = AccountType.Silver;
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
