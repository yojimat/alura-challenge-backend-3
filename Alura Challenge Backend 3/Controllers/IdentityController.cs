using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alura_Challenge_Backend_3.Controllers;

[Route("users")]
public class IdentityController : Controller
{
    private readonly IAuthService _authService;

    public IdentityController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet, Route("")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost, Route("")]
    public async Task<IActionResult> Register(UserRegisterViewModel userRegister)
    {
        if (!ModelState.IsValid) return View(userRegister);

        try
        {
            await _authService.Register(userRegister);
            await _authService.DoLogin();
        }
        catch (Exception)
        {
            // Implement some exception handling
            return View(userRegister);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet, Route(nameof(Login))]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (!ModelState.IsValid) return View(userLogin);

        try
        {
            await _authService.Login(userLogin);
            await _authService.DoLogin();
        }
        catch (Exception)
        {
            // Implement some exception handling
            return View(userLogin);
        }

        if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

        // Verify if this is necessary
        return LocalRedirect(returnUrl);
    }

    [HttpGet, Route(nameof(Logout))]
    public async Task<IActionResult> Logout()
    {
        await _authService.Logout();
        return RedirectToAction("Index", "Home");
    }
}

