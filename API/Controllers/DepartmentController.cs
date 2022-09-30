using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentRepository, Department, int>
    {
        public DepartmentController(DepartmentRepository departmentRepository) : base(departmentRepository)
        {

        }
    }
}
