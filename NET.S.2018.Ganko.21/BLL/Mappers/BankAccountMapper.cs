using BLL.Interface.Entities;
using DAL.Interface.DTO;

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
            Account newAccount = null;

            switch (account.AccountType)
            {
                case "Basic":
                    newAccount = new BasicAccount(
                        account.AccountNumber,
                        new Client(account.FirstName, account.LastName, account.PassportNumber, account.Email),
                        account.Balance);
                    break;
                case "Silver":
                    newAccount = new SilverAccount(
                        account.AccountNumber,
                        new Client(account.FirstName, account.LastName, account.PassportNumber, account.Email),
                        account.Balance);
                    break;
                case "Gold":
                    newAccount = new GoldAccount(
                        account.AccountNumber,
                        new Client(account.FirstName, account.LastName, account.PassportNumber, account.Email),
                        account.Balance);
                    break;
                case "Platinum":
                    newAccount = new PlatinumAccount(
                        account.AccountNumber,
                        new Client(account.FirstName, account.LastName, account.PassportNumber, account.Email),
                        account.Balance);
                    break;
            }

            return newAccount;
        }
    }
}
