using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountCreator
    {
        Account Create(AccountType accountType, Client client, decimal startBalance);
    }
}