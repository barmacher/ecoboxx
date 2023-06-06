using Ecobox.Domain;
using Microsoft.AspNetCore.Identity;

namespace Applications.Domain
{
    public class User : IdentityUser<int>
    {
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public string? Name { get; set; }
        public List<Application>? Applications { get; set; }
    }
}
