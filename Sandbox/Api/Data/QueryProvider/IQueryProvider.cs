using Api.Data.Entities;
using System.Linq;

namespace Api.Data.QueryProvider
{
    public interface IQueryProvider<T> where T : Entity
    {
        IQueryable<T> Queryable { get; }
    }
}