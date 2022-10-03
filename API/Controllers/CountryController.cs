using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_ADD1_TRAINER, ROLE_ADD_TRAINER_MAN, ROLE_DM_ADD, ROLE_MSCS_MAN, ROLE_DM")]
    //[Authorize(Roles = "admin, user")]
    public class CountryController :  BaseController<CountryRepository, Country, int>
    {
        public CountryController(CountryRepository countryRepository) : base(countryRepository)
        {

        }
    }
}
