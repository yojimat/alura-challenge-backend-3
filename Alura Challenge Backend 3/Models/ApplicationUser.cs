using Microsoft.AspNetCore.Identity;

namespace Alura_Challenge_Backend_3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int RegisterId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
