using BLL.Interface.Entities;
using DAL.Interface.DTO;
using BLL.Interface.Interfaces;

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

        public static Account ToAccount(this AccountDto dto, IAccountCreator creator)
        {
            return creator.Create(dto);
        }
    }
}
