using Alura_Challenge_Backend_3.Models;
using Alura_Challenge_Backend_3.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alura_Challenge_Backend_3.Controllers;

[Route("Account"), Authorize]
public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [AllowAnonymous]
    [HttpGet, Route(nameof(Login))]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [AllowAnonymous]
    [HttpPost, Route(nameof(Login))]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (!ModelState.IsValid) return View(userLogin);

        var user = await _userManager.FindByEmailAsync(userLogin.Email);

        if (user == null) user = new ApplicationUser { Email = "" };

        var result = await _signInManager.PasswordSignInAsync(
            user.UserName, userLogin.Password, false, false);

        if (result.Succeeded)
        {
            if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");
            return LocalRedirect(returnUrl);
        }

        userLogin.SetError("E-mail ou senha incorreta.");

        return View(userLogin);
    }

    [HttpGet, Route(nameof(Logout))]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("login");
    }
}

