using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role>
    {
        public RoleRepository(string request = "Role/") : base(request)
        {

        }
    }
}
