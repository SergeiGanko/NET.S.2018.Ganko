using System.Collections.Generic;

namespace WorkingWithXml.Interfaces
{
    /// <summary>
    /// Interface IStorage
    /// </summary>
    /// <typeparam name="T">contrvariant generic parameter</typeparam>
    public interface IStorage<in T>
    {
        /// <summary>
        /// Stores the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        void Store(IEnumerable<T> items);
    }
}
