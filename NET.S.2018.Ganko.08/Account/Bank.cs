using System;
using System.Collections.Generic;

namespace Account
{
    /// <summary>
    /// The Bank class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Bank<T> where T : Account
    {
        private List<T> accounts = new List<T>();

        /// <summary>
        /// Displays all accounts in the Bank.
        /// </summary>
        public void DisplayAllAccounts()
        {
            foreach (T account in accounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="startBalance">The start balance.</param>
        /// <exception cref="ArgumentException">Throws when firstName or lastName is null or whitespace</exception>
        /// <exception cref="Exception">Throws when newAccount is null</exception>
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

        /// <summary>
        /// Removes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
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

        /// <summary>
        /// Adds to deposit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="amount">The amount.</param>
        /// <exception cref="Exception">Throws when account whith specific id was not found</exception>
        public void AddToDeposit(int id, decimal amount)
        {
            T account = FindAccount(id);

            if (account == null)
            {
                throw new Exception($"Account with Id = {account.Id} not found");
            }

            account.Deposit(amount);
        }

        /// <summary>
        /// Withdraws the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="amount">The amount.</param>
        /// <exception cref="Exception">Throws when account whith specific id was not found</exception>
        public void Withdraw(int id, decimal amount)
        {
            T account = FindAccount(id);

            if (account == null)
            {
                throw new Exception($"Account with Id = {account.Id} not found");
            }

            account.Withdraw(amount);
        }

        /// <summary>
        /// Finds the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns account or null if account not found</returns>
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
