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
                new Product { 
                    Id = Guid.Parse("549ea612-6384-4191-91d9-524898c27477"),
                    Name = "Thing One",
                    Description = "This is a thing of the first kind",
                    DateAdded = new DateTime(2020, 1, 1),
                    IsActive = true
                },
                new Product {
                    Id = Guid.Parse("7028e454-c846-4dcc-95b6-4305fedc19a5"),
                    Name = "Thing Two",
                    Description = "This is a thing of the second kind",
                    DateAdded = new DateTime(2020, 3, 17),
                    IsActive = true
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.Parse("00c95228-6fa3-41ad-bc33-ff209715bc9a"), Username = "admin", Password = "Password1" }
            );
        }
    }
}