using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.Services
{
    public class AccountCreateFactory : IAccountCreateService
    {
        private readonly IAccountNumberCreateSevice accountNumberCreateSevice;

        public AccountCreateFactory(IAccountNumberCreateSevice accountNumberCreateSevice)
        {
            this.accountNumberCreateSevice = accountNumberCreateSevice;
        }

        public Account Create(AccountType accountType, Client client, decimal startBalance)
        {
            Account newAccount = null;

            switch (accountType)
            {
                case AccountType.Basic:
                    newAccount = new BasicAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                    break;
                case AccountType.Silver:
                    newAccount = new SilverAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                    break;
                case AccountType.Gold:
                    newAccount = new GoldAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                    break;
                case AccountType.Platinum:
                    newAccount = new PlatinumAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                    break;
            }

            return newAccount;
        }

        public Account Create(AccountType accountType, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
