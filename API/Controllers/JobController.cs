using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController<JobRepository, Job, int>
    {
        public JobController(JobRepository jobRepository) : base(jobRepository)
        {

        }
    }
}
