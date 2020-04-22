using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class SandboxContext: DbContext
    {
        public SandboxContext(DbContextOptions<SandboxContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
