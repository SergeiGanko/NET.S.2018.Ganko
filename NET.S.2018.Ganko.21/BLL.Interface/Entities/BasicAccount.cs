using System;

namespace BLL.Interface.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The BasicAccount class
    /// </summary>
    /// <seealso cref="T:BLL.Interface.Entities.Account" />
    public class BasicAccount : Account
    {
        #region Consts

        /// <summary>
        /// The basic account deposit value
        /// </summary>
        private const int basicAccountDepositValue = 1;

        /// <summary>
        /// The basic account balance value
        /// </summary>
        private const int basicAccountBalanceValue = 1;

        #endregion

        #region Ctors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.BasicAccount" /> class.
        /// </summary>
        internal BasicAccount()
        {
            Type = AccountType.Basic;
            DepositValue = basicAccountDepositValue;
            BalanceValue = basicAccountBalanceValue;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.BasicAccount" /> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        internal BasicAccount(string accountNumber, Client client) : this()
        {
            CkeckInput(accountNumber, client);

            AccountNumber = accountNumber;
            Client = client;
            IsClosed = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.BasicAccount" /> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="balance">The balance.</param>
        internal BasicAccount(string accountNumber, Client client, decimal balance) 
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
        /// Calculates the deposit bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateDepositBonus(decimal amount)
        {
            Bonus += (int)Math.Round((Balance * BalanceValue + amount * DepositValue) / 100);
        }

        /// <inheritdoc />
        /// <summary>
        /// Calculates the withdraw bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected override void CalculateWithdrawBonus(decimal amount)
        {
            int bonus = (int)Math.Round((Balance * BalanceValue + amount * DepositValue) / 100);

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
