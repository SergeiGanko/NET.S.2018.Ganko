using System.Collections.Generic;
using System;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity Get(TEntity entity);

        TEntity Get(string number);

        TEntity Get(int id);

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}