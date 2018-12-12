using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Document = Microsoft.Azure.Documents.Document;

namespace TraderInfo.Repository
{
    public interface ITradeRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllTradesAsync();
        Task<T> GetTradeAsync(string id);
        Task<IEnumerable<T>> GetTradesAsync(Expression<Func<T, bool>> predicate);
        Task<Document> CreateTradeAsync(T item);
        Task<Document> UpdateTradeAsync(string id, T item);
        Task DeleteTradeAsync(string id);
    }
}
