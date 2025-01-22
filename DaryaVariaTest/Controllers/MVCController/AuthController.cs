using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaryaVariaTest.Models;
using DaryaVariaTest.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace DaryaVariaTest.Controllers;

public class AuthController  : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly AuthServices _authServices;

    public AuthController(ILogger<AuthController> logger, AuthServices authServices)
    {
        _logger = logger;
        _authServices = authServices;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new LoginViewModels());
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModels model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        LoginAuth user = _authServices.Authenticate(model);

        if (user != null)
        {
            _logger.LogInformation("User authenticated successfully: {Username}", user.Username);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                });

            return RedirectToAction("Index", "Home");
        }

        ViewData["LoginError"] = "Invalid username or password.";
        return View(model);
    }

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index");
    }

}
