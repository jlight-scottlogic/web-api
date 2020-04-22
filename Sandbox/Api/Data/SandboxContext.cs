using Api.Data.Extensions;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
    }
}
