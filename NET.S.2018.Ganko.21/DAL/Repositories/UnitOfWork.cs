using DAL.Interface.Interfaces;
using System.Data.Entity;
using System;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; private set; }

        public void Commit()
        {
            this.Context?.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            try
            {
                if (disposing)
                {
                    this.Context?.Dispose();
                }
            }
            finally
            {
                this.isDisposed = true;
            }
        }
    }
}
