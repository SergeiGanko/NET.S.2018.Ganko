using System.Collections.Generic;

namespace WorkingWithXml.Interfaces
{
    /// <summary>
    /// IDataProvider interface
    /// </summary>
    /// <typeparam name="T">covariant generic output parameter</typeparam>
    public interface IDataProvider<out T>
    {
        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <returns>Returns sequence with data</returns>
        IEnumerable<T> GetAllData();
    }
}