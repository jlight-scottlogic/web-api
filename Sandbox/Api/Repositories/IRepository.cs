using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IRepository<T>
        where T: Entity
    {
        void Add(T product);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task SaveChanges();
    }
}