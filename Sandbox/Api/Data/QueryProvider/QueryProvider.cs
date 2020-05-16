using Api.Data.Entities;
using System.Linq;

namespace Api.Data.QueryProvider
{
    public class QueryProvider<T> : IQueryProvider<T> where T : Entity
    {
        private readonly SandboxContext context;

        public QueryProvider(SandboxContext context)
        {
            this.context = context;
            context.Database.EnsureCreated(); // Ignore this. It is needed for the In-Memory DbContext.
        }

        public IQueryable<T> Queryable => context.Set<T>();
    }
}
