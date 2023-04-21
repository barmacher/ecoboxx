using Applications.Domain;
using Ecobox.WebApi.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecobox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService, UserManager<User> userManager)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<string> Login(string email, string password)
        {
            return await _authService.AccessToken(email, password);
        }
    }
}
