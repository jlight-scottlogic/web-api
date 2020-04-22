using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly SandboxContext context;

        public ProductsController(SandboxContext context)
        {
            this.context = context;
        }

        // GET: products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await context.Products.ToListAsync();
        }

        // GET products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            return await context.Products.FindAsync(id);
        }

        // POST products
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody]string value)
        {
            var id = Guid.NewGuid();
            context.Products.Add(new Product { Id = id, Name = value });

            await context.SaveChangesAsync();

            return id;
        }

        // PUT products/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody]string value)
        {
            var product = await context.Products.FindAsync(id);
            product.Name = value;

            await context.SaveChangesAsync();
        }

        // DELETE products/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var product = await context.Products.FindAsync(id);
            context.Products.Remove(product);

            await context.SaveChangesAsync();
        }
    }
}
