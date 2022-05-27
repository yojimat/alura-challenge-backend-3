using Microsoft.AspNetCore.Identity;

namespace Alura_Challenge_Backend_3.Models;

public class UserViewModel
{
    public IEnumerable<ApplicationUser> UserList { get; private set; } = new List<ApplicationUser>();

    internal void SetUserList(IEnumerable<ApplicationUser> users, int loggedUserRegisterId) => 
        UserList = users.OrderByDescending(u => u.RegisterId)
                        .Where(u => u.RegisterId != 1 && u.RegisterId != loggedUserRegisterId);
}

