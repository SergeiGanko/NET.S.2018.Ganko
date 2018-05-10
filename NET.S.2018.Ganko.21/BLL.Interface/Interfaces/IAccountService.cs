using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenAccount(AccountType accountType, Client client, decimal startBalance);

        void OpenAccount(AccountType accountType, Client client);

        void CloseAccount(string accountNumber);

        void CloseAccount(Account account);

        void DepositAccount(string accountNumber, decimal amount);

        void WithdrawAccount(string accountNumber, decimal amount);

        void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount);

        //Account GetAccount(string accountNumber);

        //IEnumerable<Account> GetClientsAccounts(Client client); 
        
        //IEnumerable<Account> GetAllAccounts();
    }
}