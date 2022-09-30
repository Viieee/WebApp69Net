using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionController : BaseController<RegionRepository, Region, int>
    {
        public RegionController(RegionRepository regionRepository) : base(regionRepository)
        {

        }
    }
}
