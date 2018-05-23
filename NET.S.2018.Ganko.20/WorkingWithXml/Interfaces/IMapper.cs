using System.Collections.Generic;

namespace WorkingWithXml.Interfaces
{
    /// <summary>
    /// IMapper interface
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IMapper<in TSource, out TResult>
    {
        /// <summary>
        /// Maps the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Returns mapped result of type T</returns>
        IEnumerable<TResult> Map(IEnumerable<TSource> items);
    }
}
