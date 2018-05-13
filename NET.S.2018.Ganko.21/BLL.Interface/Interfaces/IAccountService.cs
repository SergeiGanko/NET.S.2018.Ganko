using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account OpenAccount(AccountType accountType, Client client, decimal startBalance);

        Account OpenAccount(AccountType accountType, Client client);

        void CloseAccount(string accountNumber);

        void CloseAccount(Account account);

        void DepositAccount(string accountNumber, decimal amount);

        void DepositAccount(Account account, decimal amount);

        void WithdrawAccount(string accountNumber, decimal amount);

        void WithdrawAccount(Account account, decimal amount);

        void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount);

        void Transfer(Account fromAccount, Account toAccount, decimal amount);

        Account GetByAccountNumber(string accountNumber);
        
        IEnumerable<Account> GetAllAccounts();
    }
}