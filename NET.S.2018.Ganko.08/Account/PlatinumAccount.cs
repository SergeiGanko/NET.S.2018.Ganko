using System;

namespace Account
{
    public sealed class PlatinumAccount : Account
    {
        private const int depositValue = 5;
        private const int balanceValue = 1;

        public PlatinumAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        {
            Type = AccountType.Platinum;
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
