using System;
using NUnit.Framework;
using Moq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Services;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private static IAccountNumberCreateSevice accountNumberCreateSevice =
            Mock.Of<IAccountNumberCreateSevice>(g => g.Generate() == "testAccountNumber");

        private static Mock<Client> testClient = new Mock<Client>("Uncle", "Bob", "passport", "bob@uncle.net");

        private static Mock<Client> testClient2 = new Mock<Client>("Jon", "Skeet", "passport1", "jon@skeet.net");

        private static Mock<GoldAccount> testAccount = new Mock<GoldAccount>(accountNumberCreateSevice.Generate(), testClient.Object, 999m);

        private static Mock<GoldAccount> testAccount2 = new Mock<GoldAccount>("123", testClient2.Object, 100m);

        private static IAccountCreator creator =
            Mock.Of<IAccountCreator>(c => c.Create(It.IsAny<AccountType>(), It.IsAny<Client>(), It.IsAny<decimal>()) == testAccount.Object);

        private static Mock<IRepository<AccountDto>> mockRepo = new Mock<IRepository<AccountDto>>();

        private static IAccountService service = new AccountService(creator, mockRepo.Object);


        [Test]
        public void OpenAccountTest_WithValidData()
        {
            Assert.DoesNotThrow((() => service.OpenAccount(AccountType.Gold, testClient.Object)));
            Assert.DoesNotThrow((() => service.OpenAccount(AccountType.Gold, testClient.Object, 1000)));

            mockRepo.Verify(r => r.Add(It.Is<AccountDto>(ac => 
                ac.IsClosed == false 
                && ac.AccountType == "Gold"
                && !string.IsNullOrWhiteSpace(ac.AccountNumber)
                && ac.Balance == testAccount.Object.Balance
                && ac.FirstName == testClient.Object.FirstName
                && ac.LastName == testClient.Object.LastName
                && ac.PassportNumber == testClient.Object.PassportNumber
                && ac.Email == testClient.Object.Email)));
        }

        [Test]
        public void OpenAccountTest_WithInvalidData_ExpectsExcepetions()
        {
            Assert.Throws<ArgumentNullException>((() => service.OpenAccount(AccountType.Gold, null, 0)));
            Assert.Throws<ArgumentException>((() => service.OpenAccount(AccountType.Gold, testClient.Object, -1)));
        }

        [Test]
        public void DepositAccountTest_WithValidData()
        {
            var account = service.OpenAccount(AccountType.Gold, testClient.Object, 1000m);
            decimal balance = account.Balance;
            Assert.DoesNotThrow((() => service.DepositAccount(account, 25m)));
            Assert.AreEqual(balance + 25m, account.Balance);
            mockRepo.Verify(r=>r.Update(It.Is<AccountDto>(dto => dto.Balance == balance + 25m)));
        }

        [Test]
        public void DepositAccountTest_WithInvalidData_ExpectsExceptions()
        {
            var account = service.OpenAccount(AccountType.Gold, testClient.Object, 500m);

            Assert.Throws<ArgumentException>((() => service.DepositAccount(account, -25m)));
            account = null;
            Assert.Throws<ArgumentNullException>((() => service.DepositAccount(account, 25m)));
        }

        [Test]
        public void WithdrawAccountTest_WithValidData()
        {
            //var account = service.OpenAccount(AccountType.Gold, testClient.Object, 700m);
            //decimal balance = account.Balance;
            //Assert.DoesNotThrow((() => service.WithdrawAccount(account, 25m)));
            //Assert.AreEqual((balance - 25m), account.Balance);
            //mockRepo.Verify(r => r.Update(It.Is<AccountDto>(dto => dto.Balance == balance - 25m)));
        }

        [Test]
        public void WithdrawAccountTest_WithInvalidData_ExpectsExceptions()
        {
            var account = service.OpenAccount(AccountType.Gold, testClient.Object, 500);

            Assert.Throws<ArgumentException>((() => service.WithdrawAccount(account, -25m)));
            account = null;
            Assert.Throws<ArgumentNullException>((() => service.WithdrawAccount(account, 25m)));
        }
    }
}
