using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : BaseController<LocationRepository, Location, int>
    {
        public LocationController(LocationRepository locationRepository) : base(locationRepository)
        {

        }
    }
}
