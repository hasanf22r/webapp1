using Microsoft.AspNetCore.Identity;

namespace webapp1.Models
{
    public class AppUser: IdentityUser<int>
    {
        public Address Address { get; set; }
    }
}