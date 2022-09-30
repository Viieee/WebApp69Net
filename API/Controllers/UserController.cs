using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserRepository, User, int>
    {
        public UserController(UserRepository userRepository) : base(userRepository)
        {

        }
    }
}
