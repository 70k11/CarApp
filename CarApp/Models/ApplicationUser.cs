using Microsoft.AspNetCore.Identity;

namespace CarApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
