using API.Services;
using API.Models.ViewModel;
using API.Repositories.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AuthRepository authenticationRepository;
        private IConfiguration _config;

        public AuthController(AuthRepository authenticationRepository, IConfiguration config)
        {
            this.authenticationRepository = authenticationRepository;
            this._config = config;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
            {
                return BadRequest();
            }
            var check = authenticationRepository.GetEmployee(input.Email);
            if (check == null)
            {
                return NotFound();
            }
            var result = authenticationRepository.Login(input);
            if (result != null)
            {
                var jwt = new JWTService(_config);
                string FullName = result.Employee.FirstName + " " + result.Employee.LastName;
                string role = authenticationRepository.GetRolesByUserId(result.Id);
                var token = jwt.GenerateSecurityToken(result.Id, result.Employee.Email, FullName, role);
                return Ok(new { status = 200, message = "login successful!", token = token, data = new { Id = result.Id, Email = result.Employee.Email, Name = FullName, Role = role } });
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Register input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) ||
                string.IsNullOrWhiteSpace(input.FirstName) ||
                string.IsNullOrWhiteSpace(input.LastName) ||
                string.IsNullOrWhiteSpace(input.PhoneNumber) ||
                string.IsNullOrWhiteSpace(input.Salary.ToString()) ||
                string.IsNullOrWhiteSpace(input.Username) ||
                string.IsNullOrWhiteSpace(input.Password))
            {
                return BadRequest();
            }
            var checkEmail = authenticationRepository.GetEmployee(input.Email);
            if (checkEmail != null)
            {
                return BadRequest(new { message = "user with the same email already exists!" });
            }
            var check = authenticationRepository.Get(input.Username);
            if (check != null)
            {
                return BadRequest(new { message = "user with the same username already exists!" });
            }
            int result = authenticationRepository.Register(input);
            if (result > 0)
                return Ok(new { status = 200, message = "successfully registered!" });
            return BadRequest();
        }

        [HttpPut("Change-Password")]
        public IActionResult ChangePassword(Change_Password input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) ||
                string.IsNullOrWhiteSpace(input.OldPassword) ||
                string.IsNullOrWhiteSpace(input.NewPassword))
            {
                return BadRequest();
            }
            var check = authenticationRepository.GetUserByEmail(input.Email);
            if (check == null)
            {
                return NotFound();
            }
            int result = authenticationRepository.ChangePassword(input);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();
        }

        [HttpPut("Forgot-Password")]
        public IActionResult ForgotPassword(Forget_Password input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) && string.IsNullOrWhiteSpace(input.NewPassword))
            {
                return BadRequest();
            }
            var check = authenticationRepository.GetUserByEmail(input.Email);
            if (check == null)
            {
                return NotFound();
            }
            int result = authenticationRepository.ForgetPassword(input);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();
        }
    }
}
