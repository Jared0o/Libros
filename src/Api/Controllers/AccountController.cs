using Core.Dtos.User;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _account;

        public AccountController(IAccountService account)
        {
            _account = account;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDto>> Login(UserLoginRequest request)
        {
            var response = await _account.SignIn(request);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register(UserRegisterRequest request)
        {
            var response = await _account.Register(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<UserResponseDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _account.GetCurrentUser(email);

            return user;
        }
    }
}
