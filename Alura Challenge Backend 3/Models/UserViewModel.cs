using Microsoft.AspNetCore.Identity;

namespace Alura_Challenge_Backend_3.Models;

public class UserViewModel
{
    // TODO: Should implement in IdentityUser some registry date time to sort correctly the list.
    public IEnumerable<IdentityUser> UserList { get; private set; } = new List<IdentityUser>();

    internal void SetUserList(IEnumerable<IdentityUser> users) => UserList = users;
}

