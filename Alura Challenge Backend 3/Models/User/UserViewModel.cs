namespace Alura_Challenge_Backend_3.Models.User;

public class UserViewModel
{
    public IEnumerable<ApplicationUser> UserList { get; private set; } = new List<ApplicationUser>();

    internal void SetUserList(IEnumerable<ApplicationUser> users) =>
        UserList = users.OrderByDescending(u => u.RegisterId)
                        .Where(u => u.RegisterId != 0);
}

