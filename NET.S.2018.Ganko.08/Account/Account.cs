using System;

namespace Account
{
    public abstract class Account
    {
        private static int counter = 0;

        private int id;

        protected double bonus = 0;

        protected Account(string firstName, string lastName, decimal balance)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"Error! Inconsistent {nameof(firstName)} or {nameof(lastName)}");
            }

            id = ++counter;
            Client = new Client(firstName, lastName);
            Balance = balance;
        }

        public int Id => id;

        public decimal Balance { get; internal set; }

        public Client Client { get; }

        protected AccountType Type { get; set; }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            CalculateDepositBonus(amount);
        }

        public virtual void Withdraw(decimal amount)
        {
            if (Balance < amount)
            {
                throw new ArgumentException($"Not enough minerals =)");
            }

            Balance -= amount;
            CalculateWithdrawBonus(amount);
        }

        protected abstract void CalculateDepositBonus(decimal amount);

        protected abstract void CalculateWithdrawBonus(decimal amount);

        public override string ToString()
        {
            return $"| {id} | {Type} | {Client.FirstName + Client.LastName} | {Balance} | {bonus} |";
        }
    }
}
