using Api.Data;
using Api.Models;

namespace Api.Repositories
{
    public class UserRepository: Repository<User>
    {
        public UserRepository(SandboxContext context) : base(context)
        {
        }
    }
}
