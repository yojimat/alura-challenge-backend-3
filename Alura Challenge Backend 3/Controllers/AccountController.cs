using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alura_Challenge_Backend_3.Controllers;

[Route("Account"), Authorize]
public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet, Route(nameof(Register))]
    public IActionResult Register() => View();

    
    [HttpPost, Route(nameof(Register))]
    public async Task<IActionResult> Register(UserRegisterViewModel userRegister)
    {
        if (!ModelState.IsValid) return View(userRegister);

        var user = new IdentityUser
        {
            UserName = userRegister.UserName,
            Email = userRegister.Email,
            EmailConfirmed = true
        };

        string passwordGenerated = "some_rubish";

        var result = await _userManager.CreateAsync(user, passwordGenerated);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        userRegister.SetErrors(result.Errors);

        return View(userRegister);
    }

    [AllowAnonymous]
    [HttpGet, Route(nameof(Login))]
    public IActionResult Login(string? returnUrl = null) => View();

    [AllowAnonymous]
    [HttpPost, Route(nameof(Login))]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin)
    {
        if (!ModelState.IsValid) return View(userLogin);

        var result = await _signInManager.PasswordSignInAsync(
            userLogin.Email, userLogin.Password, false, false);

        if(result.Succeeded) return RedirectToAction("Index", "Home");

        // TODO: There could a new error warning the user about an account nonexistent.
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

