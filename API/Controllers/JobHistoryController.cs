﻿using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobHistoryController : BaseController<JobHistoryRepository, JobHistory, int>
    {
        public JobHistoryController(JobHistoryRepository jobHistoryRepository) : base(jobHistoryRepository)
        {

        }
    }
}
