using System;

namespace DAL.Interface.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// UoW
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit changes.
        /// </summary>
        void Commit();
    }
}