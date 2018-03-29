using System;

namespace Account
{
    public sealed class SilverAccount : Account
    {
        private const int depositValue = 3;
        private const int balanceValue = 2;

        public SilverAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        {
            Type = AccountType.Silver;
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
