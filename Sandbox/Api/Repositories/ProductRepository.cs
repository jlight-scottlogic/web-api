using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SandboxContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await Context.Products.Where(x => x.Name == name).ToListAsync();
        }
    }
}
