using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeRepository, Employee, int>
    {
        public EmployeeController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {

        }
    }
}
