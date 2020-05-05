using Api.Data;
using Api.Models;
using System.Linq;

namespace Api.QueryProvider
{
    public class QueryProvider<T> : IQueryProvider<T> where T : Entity
    {
        private readonly SandboxContext context;

        public QueryProvider(SandboxContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Queryable => context.Set<T>();
    }
}
