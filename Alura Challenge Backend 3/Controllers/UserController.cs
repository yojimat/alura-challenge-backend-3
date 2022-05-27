using Alura_Challenge_Backend_3.Data;
using Alura_Challenge_Backend_3.Data.Contexts;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alura_Challenge_Backend_3.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, ILogger<UserController> logger)
    {
        _userManager = userManager;
        _userService= new UserService(context, logger);
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        UserViewModel userView = new();
        var users = _userService.GetUsers();
        var loggedUser = await _userManager.FindByNameAsync(User.Identity?.Name);
        userView.SetUserList(users, loggedUser.RegisterId);
        return View(nameof(Index), userView);
    }
}

