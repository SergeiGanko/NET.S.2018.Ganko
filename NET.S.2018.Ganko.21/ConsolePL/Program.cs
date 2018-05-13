using Ninject;
using DependencyResolver;
using BLL.Interface.Interfaces;
using System;
using BLL.Interface.Entities;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        private static void Main(string[] args)
        {
            var resolver = new StandardKernel();
            resolver.ConfigurateResolver();

            var service = resolver.Get<IAccountService>();

            var client1 = new Client("Vasya", "Pupkin", "MP12345567", "vasyapupkin@tut.by");
            var account1 = service.OpenAccount(AccountType.Basic, client1, 1200);
            var client2 = new Client("Petya", "Vasin", "MP7654321", "petyavasin@tut.by");
            var account2 = service.OpenAccount(AccountType.Silver, client2, 3500);
            var client3 = new Client("Fedya", "Petin", "MP1234321", "fedyapetin@tut.by");
            var account3 = service.OpenAccount(AccountType.Gold, client3, 4500);
            var client4 = new Client("Tete", "Motya", "MP2222222", "tetemotya@tut.by");
            var account4 = service.OpenAccount(AccountType.Platinum, client4, 5500);

            foreach (var account in service.GetAllAccounts())
            {
                Console.WriteLine(account);
            }

            service.DepositAccount(account1, 177);
            service.DepositAccount(account2, 73);
            service.DepositAccount(account3, 23);
            service.DepositAccount(account4, 11);

            Console.WriteLine();

            foreach (var account in service.GetAllAccounts())
            {
                Console.WriteLine(account);
            }

            service.Transfer(account1, account2, 100);
            service.Transfer(account3, account4, 50);

            Console.WriteLine();

            foreach (var account in service.GetAllAccounts())
            {
                Console.WriteLine(account);
            }

            try
            {
                service.WithdrawAccount(account1, 8000);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                service.WithdrawAccount(account2, 8000);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
            service.WithdrawAccount(account3, 8000);
            service.WithdrawAccount(account4, 8000);

            Console.WriteLine();

            foreach (var account in service.GetAllAccounts())
            {
                Console.WriteLine(account);
            }
        }
    }
}
