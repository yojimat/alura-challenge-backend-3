using Alura_Challenge_Backend_3.Data.Contexts;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Alura_Challenge_Backend_3.Data
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _appContext;
        private readonly ILogger _logger;

        public UserService(ApplicationDbContext context, ILogger logger)
        {
            _appContext = context;
            _logger = logger;
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            var usersList = _appContext.Users.AsNoTracking().Select(s => s);
            return usersList is null ? Enumerable.Empty<IdentityUser>() : usersList;
        }
    }
}
