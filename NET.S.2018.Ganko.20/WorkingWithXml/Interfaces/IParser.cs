namespace WorkingWithXml.Interfaces
{
    /// <summary>
    /// IParser interface
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IParser<in TSource, out TResult>
    {
        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>Returns parsed result</returns>
        TResult Parse(TSource source);
    }
}