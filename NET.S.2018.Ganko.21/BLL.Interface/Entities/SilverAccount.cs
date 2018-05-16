using System;

namespace BLL.Interface.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The SilverAccount class
    /// </summary>
    /// <seealso cref="T:BLL.Interface.Entities.Account" />
    public class SilverAccount : Account
    {
        #region Consts

        /// <summary>
        /// The silver account deposit value
        /// </summary>
        private const int silverAccountDepositValue = 2;

        /// <summary>
        /// The silver account balance value
        /// </summary>
        private const int silverAccountBalanceValue = 1;

        #endregion

        #region Ctors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.SilverAccount" /> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        internal SilverAccount(string accountNumber, Client client) : base(accountNumber, client)
        {
            Type = AccountType.Silver;
            DepositValue = silverAccountDepositValue;
            BalanceValue = silverAccountBalanceValue;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BLL.Interface.Entities.SilverAccount" /> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        /// <param name="balance">The balance.</param>
        internal SilverAccount(string accountNumber, Client client, decimal balance)
            : this(accountNumber, client)
        {
            Balance = balance;
            CalculateDepositBonus(balance);
        }

        internal SilverAccount(string accountNumber, Client client, decimal balance, int bonus, bool isClosed)
            : base(accountNumber, client, balance, bonus, isClosed)
        {
            Type = AccountType.Silver;
            DepositValue = silverAccountDepositValue;
            BalanceValue = silverAccountBalanceValue;
        }

        #endregion

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <exception cref="System.ArgumentException">Throws when there is not enough money on the account for the withdrawal operation</exception>
        public override decimal Balance
        {
            get => balance;
            protected set => balance = value < 0
                                           ? throw new ArgumentException($"{nameof(value)} is wrong value or more than current balance")
                                           : value;
            //protected set
            //{
            //    if (this.balance < 0)
            //    {
            //        throw new ArgumentException($"Not enough money on the account");
            //    }

            //    this.balance = value;
            //}
        }

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
    }
}
