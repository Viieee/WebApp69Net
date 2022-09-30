using Microsoft.AspNetCore.Mvc;
using WebAppClient.Controllers.Base;
using WebAppClient.Models;
using WebAppClient.Repositories.Data;

namespace WebAppClient.Controllers
{
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
