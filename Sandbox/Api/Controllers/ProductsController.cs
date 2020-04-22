using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        // GET: products
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET products/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST products
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
