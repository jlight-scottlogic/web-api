using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        void Add(T entity);

        void Remove(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task SaveChangesAsync();
    }
}