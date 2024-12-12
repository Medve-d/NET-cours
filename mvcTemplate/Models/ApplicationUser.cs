using Microsoft.AspNetCore.Identity;

namespace mvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Lastname { get; set; }
        public string? FirstName { get; set; }
    }
}