using Microsoft.AspNetCore.Mvc;
using WebAppClient.Controllers.Base;
using WebAppClient.Models;
using WebAppClient.Repositories.Data;

namespace WebAppClient.Controllers
{
    public class LocationController : BaseController<Location, LocationRepository>
    {
        public LocationController(LocationRepository repository) : base(repository)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
