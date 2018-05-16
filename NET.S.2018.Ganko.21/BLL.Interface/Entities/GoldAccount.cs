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
        /// <param name="accountNumber">The account number.</param>
        /// <param name="client">The client.</param>
        public GoldAccount(string accountNumber, Client client) : base(accountNumber, client)
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
        /// <param name="balance">The balance.</param>
        public GoldAccount(string accountNumber, Client client, decimal balance)
            : this(accountNumber, client)
        {
            Balance = balance;
            CalculateDepositBonus(balance);
        }

        internal GoldAccount(string accountNumber, Client client, decimal balance, int bonus, bool isClosed)
            : base(accountNumber, client, balance, bonus, isClosed)
        {
            Type = AccountType.Gold;
            DepositValue = goldAccountDepositValue;
            BalanceValue = goldAccountBalanceValue;
        }

        #endregion

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <exception cref="System.ArgumentException">Throws when there is not enough money on the account for the withdrawal operation</exception>
        public override decimal Balance
        {
            get => balance;
            protected set => balance = value < -25000m
                                           ? throw new ArgumentException($"{nameof(value)} is wrong value or more than current balance")
                                           : value;
            //protected set
            //{
            //    if (this.balance < -25000)
            //    {
            //        throw new ArgumentException($"Not enough money on the account");
            //    }

            //    this.balance = value;
            //}
        }

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
    }
}
