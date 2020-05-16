using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Entities;
using Api.Data.Repositories;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repo;

        public ProductsController(IProductRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Gets list of all existing products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDetailsModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<ProductDetailsModel>>> Get()
        {
            var products = (await repo.GetAllAsync())
                .Select(x => new ProductDetailsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    DateAdded = x.DateAdded,
                    IsActive = x.IsActive
                });

            return Ok(products);
        }

        /// <summary>
        /// Gets a product with the corresponding id
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns>The product</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDetailsModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDetailsModel>> Get(Guid id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return new ProductDetailsModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                DateAdded = product.DateAdded,
                IsActive = product.IsActive
            };
        }

        /// <summary>
        /// Creates a new product with an auto-generated unique id
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <returns>The generated id</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Post(ProductCreateModel product)
        {
            var id = Guid.NewGuid();

            repo.Add(new Product
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                DateAdded = product.DateAdded,
                IsActive = true
            });

            await repo.SaveChangesAsync();

            return id;
        }

        /// <summary>
        /// Updates the product with the given id with the values specified
        /// </summary>
        /// <param name="id">Product id to edit</param>
        /// <param name="product">New values</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, ProductEditModel product)
        {
            var existing = await repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.DateAdded = product.DateAdded;
            existing.IsActive = product.IsActive;

            await repo.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Removes the product with the given id
        /// </summary>
        /// <param name="id">Product id to remove</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            repo.Remove(product);

            await repo.SaveChangesAsync();

            return Ok();
        }
    }
}
