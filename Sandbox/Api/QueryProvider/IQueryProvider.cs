using Api.Models;
using System.Linq;

namespace Api.QueryProvider
{
    public interface IQueryProvider<T> where T : Entity
    {
        IQueryable<T> Queryable { get; }
    }
}