using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.Parse("549ea612-6384-4191-91d9-524898c27477"), Name = "Thing One" },
                new Product { Id = Guid.Parse("7028e454-c846-4dcc-95b6-4305fedc19a5"), Name = "Thing Two" }
            );
        }
    }
}