using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.Data.Entity;
using ORM;
using DAL.Mappers;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbContext context;

        public ClientRepository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException($"Argument {nameof(context)} is null");
        }

        public void Create(ClientDto clientDto)
        {
            CheckInput(clientDto);

            this.context.Set<Client>().Add(clientDto.ToClientOrm());
        }

        public void Update(ClientDto clientDto)
        {
            CheckInput(clientDto);

            var clientOrm = this.context.Set<Client>().Find(clientDto.PassportNumber);

            clientOrm.FirstName = clientDto.FirstName;
            clientOrm.LastName = clientDto.LastName;
            clientOrm.Passport = clientDto.PassportNumber;
            clientOrm.Email = clientDto.Email;

            this.context.Entry(clientOrm).State = EntityState.Modified;
        }

        public void Delete(ClientDto clientDto)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<ClientDto> GetAll()
        {
            return this.context.Set<Client>().ToList().Select(client => client.ToClientDto());
        }

        public ClientDto Get(int id)
        {
            throw new NotSupportedException();
        }

        public ClientDto Get(Expression<Func<ClientDto, bool>> predicate)
        {
            throw new NotSupportedException();
        }

        private void CheckInput(ClientDto clientDto)
        {
            if (ReferenceEquals(clientDto, null))
            {
                throw new ArgumentNullException($"Argument {nameof(clientDto)} is null");
            }
        }
    }
}
