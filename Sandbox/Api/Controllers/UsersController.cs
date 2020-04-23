using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        /// <summary>
        /// Gets list of all existing users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await context.Users.ToListAsync();
        }


        /// <summary>
        /// Gets current user details from HttpContext
        /// </summary>
        /// <returns>The product</returns>
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
