namespace Account
{
    using System;

    public sealed class BasicAccount : Account
    {
        private const int depositValue = 1;
        private const int balanceValue = 1;

        public BasicAccount(string firstName, string lastName, decimal balance)
            : base(firstName, lastName, balance)
        {
            Type = AccountType.Basic;
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
