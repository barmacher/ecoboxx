using Microsoft.AspNetCore.Identity;

namespace Applications.Domain
{
    public class User : IdentityUser<int>
    {
        public string? Name { get; set; }

        public List<Application>? Applications { get; set; }
    }
}
