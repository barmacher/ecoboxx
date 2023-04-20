using Applications.Domain;
using Ecobox.WebApi.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecobox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        private readonly UserManager<User> _userManager;
        public AuthController(AuthService authService, UserManager<User> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<string> Login(string email, string password)
        {
            return await _authService.AccessToken(email, password);
        }
        [HttpPost("register")]
        public async Task Register(string email, string password)
        {
            try
            {
                var user = new User()
                {
                    Id = 1,
                    Email= email,
                    UserName = email,
                };
                
               await _userManager.CreateAsync(user, password);
               //await _userManager.AddPasswordAsync(user, password);
            }
            catch (Exception e)
            {
                var test = e.Message;
                throw;
            }
        }
    }
}
