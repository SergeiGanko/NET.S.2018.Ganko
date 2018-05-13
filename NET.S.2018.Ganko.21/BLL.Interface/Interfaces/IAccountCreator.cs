using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Interface.Interfaces
{
    public interface IAccountCreator
    {
        Account Create(AccountType accountType, Client client, decimal startBalance);

        Account Create(AccountDto dto);
    }
}