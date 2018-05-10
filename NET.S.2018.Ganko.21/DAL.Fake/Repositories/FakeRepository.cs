using System;
using System.Linq;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeRepository : IRepository<AccountDto>
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
                    $"{account.FirstName} {account.LastName} is already exists");
            }

            accounts.Add(account);
        }

        public void Update(AccountDto account)
        {
            throw new NotSupportedException();
        }

        public void Delete(AccountDto account)
        {
            account.Balance = 0;
            account.Bonus = 0;
            account.IsClosed = true;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            if (!accounts.Any()) yield break;

            foreach (var account in accounts)
            {
                if (account.IsClosed != true)
                {
                    yield return account;
                }
            }
        }

        public AccountDto Get(AccountDto entity)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<AccountDto> Find(Func<AccountDto, bool> predicate)
        {
            throw new NotSupportedException();
        }
    }
}
