using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TraderInfo.Interfaces;

namespace TraderInfo.Repository
{
    public partial class AzureDBRepository<Trade> : IAzureDBRepository<Trade> where Trade : class
    {
        private DocumentClient client;

        public AzureDBRepository()
        {
            SetCollectionID();
            this.client = new DocumentClient(new Uri(Endpoint), Key);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
            
        }



        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }

        public virtual async Task<IQueryable<Trade>> GetAllTradesAsync()
        {
            IDocumentQuery<Trade> query = client.CreateDocumentQuery<Trade>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                new FeedOptions { MaxItemCount = -1 })
                //.Where(predicate)
                .AsDocumentQuery();

            List<Trade> results = new List<Trade>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<Trade>());
            }

            return results.AsQueryable();
        }

        public virtual async Task<Trade> GetTradeAsync(string id)
        {
            try
            {
                Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (Trade)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public virtual async Task<IEnumerable<Trade>> GetTradesAsync(Expression<Func<Trade, bool>> predicate)
        {
            IDocumentQuery<Trade> query = client.CreateDocumentQuery<Trade>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                new FeedOptions { MaxItemCount = -1 })
                .Where(predicate)
                .AsDocumentQuery();

            List<Trade> results = new List<Trade>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<Trade>());
            }

            return results;
        }

        public virtual async Task<Document> CreateTradeAsync(Trade item)
        {
            return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }

        public virtual async Task<Document> UpdateTradeAsync(string id, Trade item)
        {
            return await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        public virtual async Task DeleteTradeAsync(string id)
        {
            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }
    }
}
