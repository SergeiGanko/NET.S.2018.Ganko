using System;
using System.Collections.Generic;

namespace Account
{
    public sealed class Bank<T> where T : Account
    {
        private List<T> accounts = new List<T>();

        public void DisplayAllAccounts()
        {
            foreach (T account in accounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        public void CreateAccount(AccountType type, string firstName, string lastName, decimal startBalance)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"Error! Inconsistent {nameof(firstName)} or {nameof(lastName)}");
            }

            T newAccount = null;

            switch (type)
            {
                case AccountType.Basic:
                    newAccount = new BasicAccount(firstName, lastName, startBalance) as T;
                    break;
                case AccountType.Silver:
                    newAccount = new SilverAccount(firstName, lastName, startBalance) as T;
                    break;
                case AccountType.Gold:
                    newAccount = new GoldAccount(firstName, lastName, startBalance) as T;
                    break;
                case AccountType.Platinum:
                    newAccount = new PlatinumAccount(firstName, lastName, startBalance) as T;
                    break;
            }

            if (newAccount == null)
            {
                throw new Exception($"Account wasn't created!");
            }

            accounts.Add(newAccount);
        }

        public void RemoveAccount(int id)
        {
            foreach (T account in accounts)
            {
                if (account.Id == id)
                {
                    accounts.Remove(account);
                }
            }
        }

        public void AddToDeposit(int id, decimal amount)
        {
            T account = FindAccount(id);

            if (account == null)
            {
                throw new Exception($"Account with Id = {account.Id} not found");
            }

            account.Deposit(amount);
        }

        public void Withdraw(int id, decimal amount)
        {
            T account = FindAccount(id);

            if (account == null)
            {
                throw new Exception($"Account with Id = {account.Id} not found");
            }

            account.Withdraw(amount);
        }

        private T FindAccount(int id)
        {
            foreach (T account in this.accounts)
            {
                if (account.Id == id)
                {
                    return account;
                }
            }

            return null;
        }
    }
}
