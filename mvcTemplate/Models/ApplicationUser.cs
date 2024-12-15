using Microsoft.AspNetCore.Identity;

namespace mvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PersonalWebSite { get; set; }
    }
}
