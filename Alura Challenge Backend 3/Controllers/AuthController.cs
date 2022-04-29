using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alura_Challenge_Backend_3.Controllers;

[Route("users")]
public class AuthController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet, Route("")]
    public IActionResult Register() => View();

    [HttpPost, Route("")]
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

    [HttpGet, Route(nameof(Login))]
    public IActionResult Login() => View();

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin)
    {
        if (!ModelState.IsValid) return View(userLogin);

        var result = await _signInManager.PasswordSignInAsync(
            userLogin.Email, userLogin.Password, false, false);

        if(result.Succeeded) return RedirectToAction("Index", "Home");

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

