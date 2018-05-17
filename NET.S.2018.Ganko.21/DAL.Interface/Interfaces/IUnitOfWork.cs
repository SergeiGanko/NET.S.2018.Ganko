using System;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// UoW
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit changes.
        /// </summary>
        void Commit();
    }
}