using System;

namespace Account
{
    public sealed class GoldAccount : Account
    {
        private const int depositValue = 4;
        private const int balanceValue = 2;

        public GoldAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        {
            Type = AccountType.Gold;
        }

        protected override void CalculateDepositBonus(decimal amount)
        {
            this.bonus += Convert.ToDouble((amount * depositValue) / 100m);
        }

        protected override void CalculateWithdrawBonus(decimal amount)
        {
            this.bonus -= Convert.ToDouble((amount * balanceValue) / 100m);
        }
    }
}
