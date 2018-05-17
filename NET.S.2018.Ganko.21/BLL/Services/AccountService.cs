using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.Mappers;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountCreator creator;

        private readonly IRepository<AccountDto> repository;

        public AccountService(IAccountCreator creator,
                              IRepository<AccountDto> repository)
        {
            this.creator = creator ?? throw new ArgumentNullException($"Argument {nameof(creator)} is null");
            this.repository = repository ?? throw new ArgumentNullException($"Argument {nameof(repository)} is null");
        }

        public Account OpenAccount(AccountType accountType, Client client, decimal startBalance)
        {
            if (client == null)
            {
                throw new ArgumentNullException($"Argument {nameof(client)} is null");
            }

            if (startBalance < 0)
            {
                throw new ArgumentException($"Argument {nameof(startBalance)} must be greater or equal zero");
            }

            Account newAccount = this.creator.Create(accountType, client, startBalance);
            this.repository.Create(newAccount.ToAccountDto());

            return newAccount;
        }

        public Account OpenAccount(AccountType accountType, Client client)
        {
            return OpenAccount(accountType, client, 0);
        }

        public void CloseAccount(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentException($"Argument {nameof(accountNumber)} is null, empty or whitespace");
            }

            var account = repository.Get(accountNumber).ToAccount(creator);

            account.Close();

            this.repository.Delete(account.ToAccountDto());
        }

        public void CloseAccount(Account account)
        {
            CheckAccount(account);

            account.Close();

            this.repository.Delete(account.ToAccountDto());
        }

        public void DepositAccount(string accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void DepositAccount(Account account, decimal amount)
        {
            CheckAccount(account);

            account.Deposit(amount);

            this.repository.Update(account.ToAccountDto());
        }

        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            throw new NotSupportedException();
        }

        public void WithdrawAccount(Account account, decimal amount)
        {
            CheckAccount(account);

            account.Withdraw(amount);

            this.repository.Update(account.ToAccountDto());
        }

        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            throw new NotSupportedException();
        }

        public void Transfer(Account fromAccount, Account toAccount, decimal amount)
        {
            CheckAccount(fromAccount);
            CheckAccount(toAccount);

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException($"Argument {nameof(amount)} must be greater or equal zero");
            }

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

            this.repository.Update(fromAccount.ToAccountDto());
            this.repository.Update(toAccount.ToAccountDto());
        }

        public Account GetByAccountNumber(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentNullException($"Argument {nameof(accountNumber)} is null, empty or whitespace");
            }

            return repository.Get(accountNumber).ToAccount(creator);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return repository
                .GetAll()
                .Select(accountDto => accountDto.ToAccount(creator));
        }

        private void CheckAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"Argument {nameof(account)} is null");
            }
        }
    }
}
