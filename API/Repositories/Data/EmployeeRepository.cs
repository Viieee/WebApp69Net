using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, int>
    {
        public EmployeeRepository(MyContext context) : base(context)
        {

        }
    }
}
