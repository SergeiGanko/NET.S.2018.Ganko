using Account;
using System;

namespace BankAppCUI
{
    using Account = Account.Account;

    internal sealed class Program
    {
        private static void Main()
        {
            Bank<Account> bank = new Bank<Account>();

            bool alive = true;

            while (alive)
            {
                Console.WriteLine(" ~ Menu ~");
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. View all accounts");
                Console.WriteLine("3. Add to account");
                Console.WriteLine("4. Withdraw from account");
                Console.WriteLine("5. Close account");
                Console.WriteLine("6. Exit\n");

                try
                {
                    if (int.TryParse(Console.ReadLine(), out var command))
                    {
                        switch (command)
                        {
                            case 1:
                                CreateAccount(bank);
                                break;
                            case 2:
                                ViewAllAccounts(bank);
                                break;
                            case 3:
                                AddToAccount(bank);
                                break;
                            case 4:
                                WithdrawFromAccount(bank);
                                break;
                            case 5:
                                CloseAccount(bank);
                                break;
                            case 6:
                                alive = false;
                                continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ViewAllAccounts(Bank<Account> bank)
        {
            bank.DisplayAllAccounts();
        }

        private static void CreateAccount(Bank<Account> bank)
        {
            Console.WriteLine("Choose account type:\n1. Basic\n2. Silver\n3. Gold\n4. Platinum\n");
            AccountType accountType = AccountType.Basic;
            int type = Convert.ToInt32(Console.ReadLine());

            switch (type)
            {
                case 1: accountType = AccountType.Basic;
                    break;
                case 2: accountType = AccountType.Silver;
                    break;
                case 3: accountType = AccountType.Gold;
                    break;
                case 4: accountType = AccountType.Platinum;
                    break;
            }

            Console.WriteLine("Enter client's first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter client's last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter start balance:");
            decimal startBalance = Convert.ToDecimal(Console.ReadLine());

            bank.CreateAccount(accountType, firstName, lastName, startBalance);
            Console.WriteLine();
        }

        private static void WithdrawFromAccount(Bank<Account> bank)
        {
            Console.WriteLine("Enter account id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter withdrawal amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            bank.Withdraw(id, amount);
            Console.WriteLine();
        }

        private static void AddToAccount(Bank<Account> bank)
        {
            Console.WriteLine("Enter account id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            bank.AddToDeposit(id, amount);
            Console.WriteLine();
        }

        private static void CloseAccount(Bank<Account> bank)
        {
            Console.WriteLine("Enter account id:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.RemoveAccount(id);
            Console.WriteLine();
        }

    }
}
