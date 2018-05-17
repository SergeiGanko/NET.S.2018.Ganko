using DAL.Interface.DTO;
using ORM;
using System.Linq;

namespace DAL.Mappers
{
    public static class DalEntityMapper
    {
        public static Client ToClientOrm(this ClientDto dto) 
            => new Client
                   {
                       Id = dto.Id,
                       FirstName = dto.FirstName,
                       LastName = dto.LastName,
                       Passport = dto.PassportNumber,
                       Email = dto.Email
                   };

        public static ClientDto ToClientDto(this Client client)
        { 
            var result = new ClientDto
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                PassportNumber = client.Passport,
            };

            result.Accounts.AddRange(client.Accounts.Select(account => account.ToAccountDto(result)));

            return result;
        }

        public static Account ToAccountOrm(this AccountDto dto, Client client) =>
            new Account
                {
                    Id = dto.Id,
                    AccountNumber = dto.AccountNumber,
                    AccountType = new AccountType { Type = dto.AccountType },
                    Balance = dto.Balance,
                    Bonus = dto.Bonus,
                    Client = client,
                    Closed = dto.IsClosed
                };

        public static AccountDto ToAccountDto(this Account account, ClientDto client) =>
            new AccountDto
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    AccountType = account.AccountType.Type,
                    Balance = account.Balance,
                    Bonus = account.Bonus,
                    Client = client,
                    IsClosed = account.Closed
                };
    }
}
