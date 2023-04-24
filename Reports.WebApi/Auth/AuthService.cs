using Applications.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecobox.WebApi.Auth
{
    public class AuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<User> userManager, IOptions<JwtSettings> jwtsettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtsettings.Value;
        }
        public async Task<string> AccessToken(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User is not found");
            }
            var result = await _userManager.CheckPasswordAsync(user, password);
            if (result == false)
            {
                throw new Exception("Password is not correct");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var datenow = DateTime.UtcNow;
            var expire = DateTime.UtcNow.Add(TimeSpan.FromMinutes(120));
            var jwt = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                datenow, 
                expire, 
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256)
                );
            var tokenhandler = new JwtSecurityTokenHandler();
            return tokenhandler.WriteToken(jwt);


        }

    }
}
