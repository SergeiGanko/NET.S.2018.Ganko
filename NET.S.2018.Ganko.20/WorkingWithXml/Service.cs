using WorkingWithXml.Interfaces;
using System.Collections.Generic;

namespace WorkingWithXml
{
    using System;

    /// <summary>
    /// Service class
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public sealed class Service<TSource, TResult>
    {
        private readonly IStorage<TResult> storage;
        private readonly IDataProvider<TSource> dataProvider;
        private readonly IMapper<TSource, TResult> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TSource, TResult}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider instance.</param>
        /// <param name="mapper">The mapper instance.</param>
        /// <param name="storage">The storage instance.</param>
        public Service(IDataProvider<TSource> dataProvider,
                       IMapper<TSource, TResult> mapper,
                       IStorage<TResult> storage)
        {
            CheckInput(dataProvider, mapper, storage);

            this.storage = storage;
            this.mapper = mapper;
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// Exports this instance.
        /// </summary>
        public void Export()
        {
            IEnumerable<TSource> lines = this.dataProvider.GetAllData();

            IEnumerable<TResult> items = this.mapper.Map(lines);

            this.storage.Store(items);
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when argument dataProvider is null
        /// or Throws when argument mapper is null
        /// or Throws when argument storage is null
        /// </exception>
        private void CheckInput(IDataProvider<TSource> dataProvider,
                                IMapper<TSource, TResult> mapper, 
                                IStorage<TResult> storage)
        {
            if (dataProvider == null)
            {
                throw new ArgumentNullException($"Argument {nameof(dataProvider)} is null");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException($"Argument {nameof(mapper)} is null");
            }

            if (storage == null)
            {
                throw new ArgumentNullException($"Argument {nameof(storage)} is null");
            }
        }
    }
}
