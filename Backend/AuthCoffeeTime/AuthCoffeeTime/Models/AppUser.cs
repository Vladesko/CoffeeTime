using Microsoft.AspNetCore.Identity;

namespace AuthCoffeeTime.Models
{
    public class AppUser : IdentityUser
    {
        public int SecretCode { get; set; }
    }
}
