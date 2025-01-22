using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaryaVariaTest.Models;
using DaryaVariaTest.Services;

namespace DaryaVariaTest.Controllers;

public class AuthController  : Controller
{
    private readonly ILogger<AuthController > _logger;
    private readonly AuthServices _services;

    public AuthController (ILogger<AuthController> logger, AuthServices services) {
        _logger = logger;
        _services = services;
    }

    [HttpGet]
    public IActionResult Index() {
        Console.WriteLine("test get");
        return View(new LoginViewModels());
    }

    [HttpPost]
    public IActionResult Index(LoginViewModels lvm) {
        _logger.LogInformation("Login post requested");

        if (!ModelState.IsValid) {
            return View(lvm);  // Return the view with validation errors if ModelState is invalid.
        }

        _services.GetAuthentication(lvm);
        
        if (lvm.UsernameOrEmail == "admin" && lvm.Password == "password123") {
            _logger.LogInformation("User authenticated successfully.");
            return RedirectToAction("Index", "Home");  // Redirect to the home page or desired page.
        } else {
            ViewData["LoginError"] = "Invalid username or password.";
            return View(lvm);  // Return the view with the error message.
        }
    }

}
