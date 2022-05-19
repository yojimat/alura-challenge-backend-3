using Microsoft.AspNetCore.Identity;

namespace Alura_Challenge_Backend_3.Data.Interfaces
{
    public interface IUserService
    {
        IEnumerable<IdentityUser> GetUsers();
    }
}
