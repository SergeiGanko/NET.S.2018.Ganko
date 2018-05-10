using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// The PlatinumAccount class
    /// </summary>
    /// <seealso cref="Account" />
    public sealed class PlatinumAccount : Account
    {
        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        public PlatinumAccount(string accountNumber, Client client) : base(accountNumber, client)
        {
            Type = AccountType.Platinum;
            DepositValue = 5;
            BalanceValue = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="balance">The balance.</param>
        public PlatinumAccount(string accountNumber, Client client, decimal balance)
            : this(accountNumber, client)
        {
            if (balance < 0)
            {
                throw new ArgumentOutOfRangeException($"Argument {nameof(balance)} must be greater than zero");
            }

            Balance = balance;
            CalculateDepositBonus(balance);
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Calculates the deposit bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateDepositBonus(decimal amount)
        {
            Bonus += (int)Math.Round((Balance * BalanceValue + amount * DepositValue) / 50);
        }

        /// <summary>
        /// Calculates the withdraw bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateWithdrawBonus(decimal amount)
        {
            int bonus = (int)((Balance * BalanceValue + amount * DepositValue) / 10000);

            if (Bonus >= bonus)
            {
                Bonus -= bonus;
            }
            else
            {
                Bonus = 0;
            }
        }

        #endregion
    }
}
