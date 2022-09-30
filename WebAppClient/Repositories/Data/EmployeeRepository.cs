using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee>
    {
        public EmployeeRepository(string request = "Employee/") : base(request)
        {

        }
    }
}
