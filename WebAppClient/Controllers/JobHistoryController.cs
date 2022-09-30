﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppClient.Controllers.Base;
using WebAppClient.Models;
using WebAppClient.Repositories.Data;

namespace WebAppClient.Controllers
{
    public class JobHistoryController : BaseController<JobHistory, JobHistoryRepository>
    {
        public JobHistoryController(JobHistoryRepository repository) : base(repository)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
