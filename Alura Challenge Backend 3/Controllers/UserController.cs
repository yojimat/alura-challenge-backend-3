using Alura_Challenge_Backend_3.Data;
using Alura_Challenge_Backend_3.Data.Contexts;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Models;
using Alura_Challenge_Backend_3.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Alura_Challenge_Backend_3.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;
    private readonly IConfiguration _config;
    public UserController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ApplicationDbContext context,
        ILogger<UserController> logger,
        IConfiguration config)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userService = new UserService(context, logger);
        _logger = logger;
        _config = config;
    }

    public IActionResult Index()
    {
        UserViewModel userView = new();
        var users = _userService.GetUsers();
        userView.SetUserList(users);
        return View(nameof(Index), userView);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserViewModel newUser)
    {
        if (!ModelState.IsValid) return View();

        Random rnd = new();
        string password = rnd.Next(999_999).ToString();

        ApplicationUser newAppUser = new()
        {
            Name = newUser.Name,
            Email = newUser.Email,
            UserName = Guid.NewGuid().ToString(),
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(newAppUser, password);

        if (!result.Succeeded)
        {
            newUser.Error = "E-mail já cadastrado";
            return View(newUser);
        }

        try
        {
            // TODO: Refactor this part of the code to a class
            MailMessage message = new(_config["EmailRegisterUser"], newUser.Email);
            SmtpClient client = new(" smtp-mail.outlook.com", 587)
            {
                Credentials = new NetworkCredential(_config["EmailRegisterUser"], _config["PasswordRegisterUser"]),
                EnableSsl = true
            };

            message.Subject = "Senha gerada Alura Challenge 3";
            message.IsBodyHtml = true;
            message.Body = $"Senha: {password}";

            client.Send(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await _userManager.DeleteAsync(newAppUser);
            newUser.Error = "Não foi possível finalizar seu cadastro, tente novamente mais tarde.";
            return View(newUser);
        }


        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return RedirectToAction(nameof(Index));
        EditUserViewModel editUser = new()
        {
            Name = user.Name,
            Id = user.Id
        };
        return View(editUser);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditUserViewModel updatedUser)
    {
        if (!ModelState.IsValid) return View(updatedUser.Id);

        var oldUser = await _userManager.FindByIdAsync(updatedUser.Id);
        oldUser.Name = updatedUser.Name;
        var result = await _userManager.UpdateAsync(oldUser);

        if (!result.Succeeded)
        {
            Console.WriteLine("Do something");
        }

        return RedirectToAction(nameof(Index));
    }
}
