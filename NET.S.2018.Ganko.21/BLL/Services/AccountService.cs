using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.Services
{
    using DAL.Interface.DTO;

    public sealed class AccountService : IAccountService
    {
        private IAccountNumberCreateSevice _accountNumberCreateSevice;

        private IRepository<AccountDto> _repository;

        public AccountService(IAccountNumberCreateSevice accountNumberCreateSevice,
                              IRepository<AccountDto> repository)
        {
            _accountNumberCreateSevice = accountNumberCreateSevice ?? throw new ArgumentNullException($"Argument {nameof(accountNumberCreateSevice)} is null");
            _repository = repository ?? throw new ArgumentNullException($"Argument {nameof(repository)} is null");
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

            Account newAccount = null;
        }

        public void OpenAccount(AccountType accountType, Client client)
        {
            throw new NotImplementedException();
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
