using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.Linq.Expressions;

namespace DAL.Fake.Repositories
{
    public class FakeRepository : IFakeRepository
    {
        private readonly List<AccountDto> accounts;

        public FakeRepository()
        {
            accounts = new List<AccountDto>();
        }

        public void Create(AccountDto account)
        {
            if (accounts.Contains(account))
            {
                throw new InvalidOperationException(
                    $"The account: №{account.AccountNumber}, " + 
                    $"{account.Client.FirstName} {account.Client.LastName} is already exists");
            }

            accounts.Add(account);
        }

        public void Update(AccountDto account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"Argument {nameof(account)} is null");
            }

            int index = this.accounts.FindIndex(a => a.AccountNumber == account.AccountNumber);

            if (index < 0)
            {
                throw new ApplicationException($"Account not found");
            }

            this.accounts.RemoveAt(index);
            this.accounts.Insert(index, account);
        }

        public void Delete(AccountDto account)
        {
            Update(account);
        }

        public IEnumerable<AccountDto> GetAll()
        {
            return accounts;
        }

        public AccountDto Get(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentNullException($"Argument {nameof(accountNumber)} is null or empty");
            }

            return this.accounts.Find(a => a.AccountNumber == accountNumber);
        }

        public AccountDto Get(int id)
        {
            throw new NotSupportedException();
        }

        public AccountDto Get(Expression<Func<AccountDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public AccountDto Get(AccountDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Argument {nameof(entity)} is null or empty");
            }

            return this.accounts.Find(a => a.AccountNumber == entity.AccountNumber);
        }
    }
}
