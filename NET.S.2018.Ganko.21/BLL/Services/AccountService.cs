using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.Factories;
using BLL.Mappers;

namespace BLL.Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly IAccountCreator creator;

        private readonly IRepository<AccountDto> repository;

        public AccountService(IAccountCreator creator,
                              IRepository<AccountDto> repository)
        {
            this.creator = creator ?? throw new ArgumentNullException($"Argument {nameof(creator)} is null");
            this.repository = repository ?? throw new ArgumentNullException($"Argument {nameof(repository)} is null");
        }

        public void OpenAccount(AccountType accountType, Client client, decimal startBalance)
        {
            if (client == null)
            {
                throw new ArgumentNullException($"Argument {nameof(client)} is null");
            }

            if (startBalance < 0)
            {
                throw new ArgumentOutOfRangeException($"Argument {nameof(startBalance)} must be greater or equal zero");
            }

            Account newAccount = this.creator.Create(accountType, client, startBalance);
            this.repository.Create(newAccount.ToAccountDto());

        }

        public void OpenAccount(AccountType accountType, Client client)
        {
            throw new NotSupportedException();
        }

        public void CloseAccount(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentException($"Argument {nameof(accountNumber)} is null, empty or whitespace");
            }


        }

        public void CloseAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"Argument {nameof(account)} is null");
            }


        }

        public void DepositAccount(string accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
