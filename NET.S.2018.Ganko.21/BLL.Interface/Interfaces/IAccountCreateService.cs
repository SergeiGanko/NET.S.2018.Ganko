namespace BLL.Interface.Interfaces
{
    using BLL.Interface.Entities;

    public interface IAccountCreateService
    {
        Account Create(AccountType accountType, Client client, decimal startBalance);

        Account Create(AccountType accountType, Client client);
    }
}