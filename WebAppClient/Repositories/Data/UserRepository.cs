using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class UserRepository : GeneralRepository<User>
    {
        public UserRepository(string request = "User/") : base(request)
        {

        }
    }
}
