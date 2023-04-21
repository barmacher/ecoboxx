using Applications.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecobox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManageController : ControllerBase
    {
        public readonly UserManager<User> _userManager;

        public UserManageController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task Register(string email, string password)
        {
            var user = new User()
            {
                Email = email,
                UserName = email
            };

            var existingUser = await _userManager.FindByNameAsync(user.UserName);

            if (existingUser != null)
                throw new Exception("User with such email already exists");

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception(
                    result.Errors
                        .Select(error => error.Description)
                        .Aggregate((x, y) => x + ";" + y));
            }
        }
    }
}
