using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, int>
    {
        public UserRepository(MyContext context) : base(context)
        {

        }
    }
}
