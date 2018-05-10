using BLL.Interface.Entities;
using DAL.Interface.DTO;
using BLL.Services;
using BLL.Factories;

namespace BLL.Mappers
{
    public static class BankAccountMapper
    {
        public static AccountDto ToAccountDto(this Account account) =>
            new AccountDto
                {
                    AccountNumber = account.AccountNumber,
                    AccountType = account.Type.ToString(),
                    Balance = account.Balance,
                    Bonus = account.Bonus,
                    Email = account.Client.Email,
                    FirstName = account.Client.FirstName,
                    LastName = account.Client.LastName,
                    PassportNumber = account.Client.PassportNumber,
                    IsClosed = account.IsClosed
                };

        public static Account ToAccount(this AccountDto account)
        {
            AccountType type = AccountType.Basic;

            if (account.AccountType == "Silver")
            {
                type = AccountType.Silver;
            }
            else if (account.AccountType == "Gold")
            {
                type = AccountType.Gold;
            }
            else if (account.AccountType == "Platinum")
            {
                type = AccountType.Platinum;
            }

            var creator = new AccountCreator(new AccountNumberCreateSevice());

            return creator.Create(type,
                new Client(account.FirstName, account.LastName, account.PassportNumber, account.Email),
                account.Balance);
        }
    }
}
