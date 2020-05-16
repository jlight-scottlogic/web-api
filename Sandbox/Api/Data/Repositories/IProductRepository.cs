using Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByName(string name);
    }
}
