using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.Data.Entity;
using ORM;
using System.Linq.Expressions;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext context;

        public AccountRepository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException($"Argument {nameof(context)} is null");
        }

        public void Create(AccountDto accountDto)
        {
            CheckInput(accountDto);

            var clientOrm = this.context.Set<Client>().Include(c => c.Accounts)
                .FirstOrDefault(c => string.Equals(c.Passport, accountDto.Client.PassportNumber));

            this.context.Set<Account>().Add(accountDto.ToAccountOrm(clientOrm));
        }

        public void Update(AccountDto accountDto)
        {
            CheckInput(accountDto);

            var accountOrm = this.context.Set<Account>().FirstOrDefault(a => a.Id == accountDto.Id);

            accountOrm.Balance = accountDto.Balance;
            accountOrm.Bonus = accountDto.Bonus;
            this.context.Entry(accountOrm).State = EntityState.Modified;
        }

        public void Delete(AccountDto accountDto)
        {
            CheckInput(accountDto);

            var accountOrm = this.context.Set<Account>().FirstOrDefault(a => a.Id == accountDto.Id);

            accountOrm.Balance = accountDto.Balance;
            accountOrm.Bonus = accountDto.Bonus;
            accountOrm.Closed = accountDto.IsClosed;
            this.context.Entry(accountOrm).State = EntityState.Modified;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            return this.context.Set<Account>()
                .Include(c => c.Client)
                .Include(a => a.AccountType)
                .Where(p => p.Closed == false)
                .Select(a => a.ToAccountDto(a.Client.ToClientDto()))
                .ToList();
        }

        public AccountDto Get(int id)
        {
            throw new NotSupportedException();
        }

        public AccountDto Get(Expression<Func<AccountDto, bool>> predicate)
        {
            throw new NotSupportedException();
        }

        private void CheckInput(AccountDto accountDto)
        {
            if (ReferenceEquals(accountDto, null))
            {
                throw new ArgumentNullException($"Argument {nameof(accountDto)} is null");
            }
        }
    }
}
