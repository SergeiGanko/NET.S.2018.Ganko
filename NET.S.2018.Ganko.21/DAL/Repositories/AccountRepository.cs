using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.Data.Entity;
using ORM;

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

            // TODO
        }

        public void Update(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountDto Get(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }

        public AccountDto Get(string number)
        {
            throw new NotImplementedException();
        }

        public AccountDto Get(int id)
        {
            throw new NotImplementedException();
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
