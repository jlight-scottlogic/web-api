using Api.Data;
using Api.Models;
using Api.Security.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Security
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SandboxContext context;

        public UserAuthenticationService(SandboxContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
