using Microsoft.AspNetCore.Identity;

namespace WebAppAuth.Models
{
    public class CustomUser : IdentityUser
    {
        public Gender Gender { get; set; }
        public string Address { get; set; }
    }
}
