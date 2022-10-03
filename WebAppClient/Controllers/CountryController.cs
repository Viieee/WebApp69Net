using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Controllers.Base;
using WebAppClient.Models;
using WebAppClient.Repositories.Data;

namespace WebAppClient.Controllers
{
    //[Authorize(Roles = "admin, user")]
    public class CountryController : BaseController<Country, CountryRepository>
    {
        public CountryController(CountryRepository repository) : base(repository)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
