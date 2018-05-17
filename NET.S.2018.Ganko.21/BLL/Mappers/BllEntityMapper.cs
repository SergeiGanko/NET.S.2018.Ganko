using BLL.Interface.Entities;
using DAL.Interface.DTO;
using BLL.Interface.Interfaces;

namespace BLL.Mappers
{
    public static class BllEntityMapper
    {
        public static ClientDto ToClientDto(this Client client)
        {
            return new ClientDto
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                PassportNumber = client.PassportNumber,
                Email = client.Email
            };
        }

        public static Client ToClientBll(this ClientDto dto)
        {
             return new Client
             {
                 Id = dto.Id,
                 FirstName = dto.FirstName,
                 LastName = dto.LastName,
                 PassportNumber = dto.PassportNumber,
                 Email = dto.Email
             };
        }

        public static AccountDto ToAccountDto(this Account account)
        {
            return new AccountDto
            {
                AccountNumber = account.AccountNumber,
                AccountType = account.Type.ToString(),
                Balance = account.Balance,
                Bonus = account.Bonus,
                Client = account.Client.ToClientDto(),
                IsClosed = account.IsClosed
            };
        }

        public static Account ToAccount(this AccountDto dto, IAccountCreator creator)
        {
            return creator.Create(dto);
        }
    }
}
