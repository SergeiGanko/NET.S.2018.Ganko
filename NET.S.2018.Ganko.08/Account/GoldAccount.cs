using System;

namespace Account
{
    /// <summary>
    /// The GoldAccount class
    /// </summary>
    /// <seealso cref="Account" />
    public sealed class GoldAccount : Account
    {
        private const int depositValue = 4;
        private const int balanceValue = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="balance">The balance.</param>
        public GoldAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        {
            Type = AccountType.Gold;
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
