using Api.Data.QueryProvider;
using Api.Models;
using Api.Security.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Security
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IQueryProvider<User> provider;

        public UserAuthenticationService(IQueryProvider<User> provider)
        {
            this.provider = provider;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await provider.Queryable.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
