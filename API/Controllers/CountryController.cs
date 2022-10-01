﻿using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController :  BaseController<CountryRepository, Country, int>
    {
        public CountryController(CountryRepository countryRepository) : base(countryRepository)
        {

        }
    }
}
