using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity Get(TEntity entity);

        TEntity Get(string number);

        TEntity Get(int id);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);
    }
}