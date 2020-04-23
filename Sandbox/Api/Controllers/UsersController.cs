using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly SandboxContext context;

        public UsersController(SandboxContext context)
        {
            this.context = context;
        }

        // GET: users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("current")]
        public IActionResult GetCurrent()
        {
            return Ok(new
            {
                Identity = HttpContext.User.Identity.Name,
                Claims = HttpContext.User.Claims.Select(x => $"{x.Type}: {x.Value}")
            });
        }
    }
}
