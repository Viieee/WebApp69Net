using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class UserRoleRepository : GeneralRepository<UserRole>
    {
        public UserRoleRepository(string request = "UserRole/") : base(request)
        {

        }
    }
}
