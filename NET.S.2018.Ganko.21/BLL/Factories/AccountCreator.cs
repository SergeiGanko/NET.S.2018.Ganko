using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace BLL.Factories
{
    public class AccountCreator : IAccountCreator
    {
        /// <summary>
        /// The account number create sevice
        /// </summary>
        private readonly IAccountNumberCreateSevice accountNumberCreateSevice;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCreator"/> class.
        /// </summary>
        /// <param name="accountNumberCreateSevice">The account number create sevice.</param>
        public AccountCreator(IAccountNumberCreateSevice accountNumberCreateSevice)
        {
            this.accountNumberCreateSevice = accountNumberCreateSevice;
        }

        /// <summary>
        /// Creates the specified account type.
        /// </summary>
        /// <param name="accountType">Type of the account.</param>
        /// <param name="client">The client.</param>
        /// <param name="startBalance">The start balance.</param>
        /// <returns>Returns some type of bank account instance</returns>
        /// <exception cref="InvalidOperationException">Throw when account type doesn't exist</exception>
        public virtual Account Create(AccountType accountType, Client client, decimal startBalance)
        {
            switch (accountType)
            {
                case AccountType.Basic:
                    return new BasicAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                case AccountType.Silver:
                    return new SilverAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                case AccountType.Gold:
                    return new GoldAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                case AccountType.Platinum:
                    return new PlatinumAccount(
                        this.accountNumberCreateSevice.Generate(),
                        client,
                        startBalance);
                default: throw new InvalidOperationException($"The following account type {accountType} doesn't exist");
            }
        }

        public Account Create(AccountDto dto)
        {
            switch (dto.AccountType)
            {
                case "Basic":
                    return new BasicAccount
                    {
                        AccountNumber = dto.AccountNumber,
                        Client = new Client(
                                       dto.FirstName,
                                       dto.LastName,
                                       dto.PassportNumber,
                                       dto.Email),
                        Balance = dto.Balance,
                        Bonus = dto.Bonus,
                        Type = AccountType.Basic,
                        IsClosed = dto.IsClosed
                    };
                case "Silver":
                    return new SilverAccount
                    {
                        AccountNumber = dto.AccountNumber,
                        Client = new Client(
                                       dto.FirstName,
                                       dto.LastName,
                                       dto.PassportNumber,
                                       dto.Email),
                        Balance = dto.Balance,
                        Bonus = dto.Bonus,
                        Type = AccountType.Silver,
                        IsClosed = dto.IsClosed
                    };
                case "Gold":
                    return new GoldAccount
                    {
                        AccountNumber = dto.AccountNumber,
                        Client = new Client(
                                       dto.FirstName,
                                       dto.LastName,
                                       dto.PassportNumber,
                                       dto.Email),
                        Balance = dto.Balance,
                        Bonus = dto.Bonus,
                        Type = AccountType.Gold,
                        IsClosed = dto.IsClosed
                    };
                case "Platinum":
                    return new PlatinumAccount
                    {
                        AccountNumber = dto.AccountNumber,
                        Client = new Client(
                                       dto.FirstName,
                                       dto.LastName,
                                       dto.PassportNumber,
                                       dto.Email),
                        Balance = dto.Balance,
                        Bonus = dto.Bonus,
                        Type = AccountType.Platinum,
                        IsClosed = dto.IsClosed
                    };
                default: throw new InvalidOperationException($"The following account type {dto.AccountType} doesn't exist");
            }
        }
    }
}
