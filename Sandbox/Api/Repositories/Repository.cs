using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly SandboxContext context;

        public Repository(SandboxContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void Add(T T)
        {
            context.Set<T>().Add(T);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
