using System;

namespace BLL.Interface.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The PlatinumAccount class
    /// </summary>
    /// <seealso cref="T:BLL.Interface.Entities.Account" />
    public class PlatinumAccount : Account
    {
        #region Consts

        /// <summary>
        /// The platinum account deposit value
        /// </summary>
        private const int platinumAccountDepositValue = 5;

        /// <summary>
        /// The platinum account balance value
        /// </summary>
        private const int platinumAccountBalanceValue = 1;

        #endregion

        #region Ctors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.PlatinumAccount" /> class.
        /// </summary>
        internal PlatinumAccount()
        {
            Type = AccountType.Platinum;
            DepositValue = platinumAccountDepositValue;
            BalanceValue = platinumAccountBalanceValue;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.PlatinumAccount" /> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        internal PlatinumAccount(string accountNumber, Client client) : this()
        {
            CkeckInput(accountNumber, client);

            AccountNumber = accountNumber;
            Client = client;
            IsClosed = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.PlatinumAccount" /> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="balance">The balance.</param>
        internal PlatinumAccount(string accountNumber, Client client, decimal balance)
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

        /// <inheritdoc />
        /// <summary>
        /// Calculates the deposit bonus even if balance is negative.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateDepositBonus(decimal amount)
        {
            Bonus += (int)Math.Round((Balance * BalanceValue + amount * DepositValue) / 50);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        /// <summary>
        /// Withdraws the money. Allows to have a negative balance 
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void WithdrawMoney(decimal amount)
        {
            Balance -= amount;

            CalculateWithdrawBonus(amount);
        }

        #endregion
    }
}
