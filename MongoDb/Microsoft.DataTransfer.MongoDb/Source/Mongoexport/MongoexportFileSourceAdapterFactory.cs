﻿using Microsoft.DataTransfer.Basics;
using Microsoft.DataTransfer.Extensibility;
using Microsoft.DataTransfer.Extensibility.Basics.Source;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.MongoDb.Source.Mongoexport
{
    /// <summary>
    /// Provides data source adapters capable of reading data from one or more mongoexport JSON files.
    /// </summary>
    public sealed class MongoexportFileSourceAdapterFactory : IDataSourceAdapterFactory<IMongoexportFileSourceAdapterConfiguration>
    {
        /// <summary>
        /// Gets the description of the data adapter.
        /// </summary>
        public string Description
        {
            get { return Resources.MongoexportSourceDescription; }
        }

        /// <summary>
        /// Creates a new instance of <see cref="IDataSourceAdapter" /> with the provided configuration.
        /// </summary>
        /// <param name="configuration">Data source adapter configuration.</param>
        /// <param name="context">Data transfer operation context.</param>
        /// <returns>Task that represents asynchronous create operation.</returns>
        public Task<IDataSourceAdapter> CreateAsync(IMongoexportFileSourceAdapterConfiguration configuration, IDataTransferContext context)
        {
            return Task.Factory.StartNew(() => Create(configuration));
        }

        private IDataSourceAdapter Create(IMongoexportFileSourceAdapterConfiguration configuration)
        {
            Guard.NotNull("configuration", configuration);

            return new AggregateDataSourceAdapter(
                configuration.Files
                    .SelectMany(p => DirectoryHelper
                        .EnumerateFiles(p)
                        .Select(f => new MongoexportFileSourceAdapter(f))));
        }
    }
}
