using System.Collections.Generic;
using WorkingWithXml.Interfaces;

namespace WorkingWithXml
{
    /// <summary>
    /// Class Mapper
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="WorkingWithXml.Interfaces.IMapper{TSource, TResult}" />
    public class Mapper<TSource, TResult> : IMapper<TSource, TResult>
    {
        /// <summary>
        /// The parser instance
        /// </summary>
        private readonly IParser<TSource, TResult> parser;

        /// <summary>
        /// The logger instance
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper{TSource, TResult}"/> class.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="logger">The logger.</param>
        public Mapper(IParser<TSource, TResult> parser, ILogger logger)
        {
            this.parser = parser;
            this.logger = logger;
        }

        /// <summary>
        /// Maps the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>
        /// Returns sequence of mapped result of type T
        /// </returns>
        public IEnumerable<TResult> Map(IEnumerable<TSource> items)
        {
            foreach (var item in items)
            {
                var result = this.parser.Parse(item);

                if (result != null)
                {
                    yield return result;
                }
                else
                {
                    this.logger.Log($"String: {item} cannot be parsed to url");
                }
            }
        }
    }
}
