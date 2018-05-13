using System;

namespace BLL.Interface.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The GoldAccount class
    /// </summary>
    /// <seealso cref="T:BLL.Interface.Entities.Account" />
    public class GoldAccount : Account
    {
        #region Consts

        /// <summary>
        /// The gold account deposit value
        /// </summary>
        private const int goldAccountDepositValue = 4;

        /// <summary>
        /// The gold account balance value
        /// </summary>
        private const int goldAccountBalanceValue = 2;

        #endregion

        #region Ctors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.GoldAccount" /> class.
        /// </summary>
        internal GoldAccount()
        {
            Type = AccountType.Gold;
            DepositValue = goldAccountDepositValue;
            BalanceValue = goldAccountBalanceValue;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.GoldAccount" /> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        public GoldAccount(string accountNumber, Client client) : this()
        {
            CkeckInput(accountNumber, client);

            AccountNumber = accountNumber;
            Client = client;
            IsClosed = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.GoldAccount" /> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        /// <param name="balance">The balance.</param>
        public GoldAccount(string accountNumber, Client client, decimal balance)
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
        /// Calculates the deposit bonus if balance is positive.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateDepositBonus(decimal amount)
        {
            if (Balance > 0)
            {
                Bonus += (int)Math.Round((Balance * BalanceValue + amount * DepositValue) / 100);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Calculates the withdraw bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateWithdrawBonus(decimal amount)
        {
            int bonus = (int)Math.Round((Balance * BalanceValue + amount * DepositValue) / 200);

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
