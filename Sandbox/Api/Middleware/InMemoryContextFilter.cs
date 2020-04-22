using Api.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class InMemoryContextFilter : IAsyncActionFilter
    {
        private readonly SandboxContext dbContext;

        public InMemoryContextFilter(SandboxContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            await dbContext.Database.EnsureCreatedAsync();
            await next();
        }
    }
}
