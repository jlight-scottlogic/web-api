using Api.Models;

namespace Api.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(SandboxContext context) : base(context)
        {
        }
    }
}
