using Microsoft.AspNetCore.Mvc;
using WebAppClient.Controllers.Base;
using WebAppClient.Models;
using WebAppClient.Repositories.Data;

namespace WebAppClient.Controllers
{
    public class EmployeeController : BaseController<Employee, EmployeeRepository>
    {
        public EmployeeController(EmployeeRepository repository) : base(repository)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
