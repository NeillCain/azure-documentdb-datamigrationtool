﻿using Microsoft.DataTransfer.DocumentDb.Sink;
using System;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.DocumentDb.Client
{
    interface IDocumentDbWriteClient : IDisposable
    {
        Task<string> GetOrCreateCollectionAsync(string collectionName, CollectionPricingTier collectionTier);
        Task CreateDocumentAsync(string collectionLink, object document, bool disableAutomaticIdGeneration);

        Task<string> CreateStoredProcedureAsync(string collectionLink, string name, string body);
        Task<TResult> ExecuteStoredProcedureAsync<TResult>(string storedProcedureLink, params dynamic[] args);
        Task DeleteStoredProcedureAsync(string storedProcedureLink);
    }
}
