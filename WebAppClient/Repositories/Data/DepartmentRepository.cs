using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<Department>
    {
        public DepartmentRepository(string request = "Department/") : base(request)
        {

        }
    }
}
