using Microsoft.AspNetCore.Identity;


namespace CarsTARge22.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
