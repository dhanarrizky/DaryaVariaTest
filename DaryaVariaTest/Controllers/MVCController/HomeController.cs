using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaryaVariaTest.Models;
using DaryaVariaTest.Services;

namespace DaryaVariaTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly OrderServices _service;
    private readonly ChartServices _chartService;

    public HomeController(ILogger<HomeController> logger, OrderServices services, ChartServices chartServices) {
        _logger = logger;
        _service = services;
        _chartService = chartServices;
    }

    public IActionResult Index() {
        _logger.LogInformation("Home Transaction");
        var res = _service.GetAllTransaction();
        return View(res);
    }

    public IActionResult Showchart() {
        var viewModel = _chartService.GetChartShow();
        return View(viewModel);
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
