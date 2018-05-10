using System.Collections.Generic;
using System;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity Get(TEntity entity);

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}