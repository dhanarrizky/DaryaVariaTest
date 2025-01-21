using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaryaVariaTest.Models;
using DaryaVariaTest.Services;

namespace DaryaVariaTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly OrderServices _service;

    public HomeController(ILogger<HomeController> logger, OrderServices services) {
        _logger = logger;
        _service = services;
    }

    public IActionResult Index() {
        _logger.LogInformation("Home Transaction");
        var res = _service.GetAllTransaction();
        return View(res);
    }

    public IActionResult Showchart() {
        var viewModel = new ChartViewModel
        {
            Labels = new[] { "2017", "2018", "2019" },
            Datasets = new List<ChartViewModel.Dataset>
            {
                new ChartViewModel.Dataset
                {
                    Label = "Buku Tulis",
                    Data = new[] { 40000000, 50000000, 60000000 },
                    BackgroundColor = "rgba(75, 192, 192, 0.6)"
                },
                new ChartViewModel.Dataset
                {
                    Label = "Balpen",
                    Data = new[] { 20000000, 30000000, 40000000 },
                    BackgroundColor = "rgba(153, 102, 255, 0.6)"
                },
                new ChartViewModel.Dataset
                {
                    Label = "Pensil",
                    Data = new[] { 15000000, 25000000, 35000000 },
                    BackgroundColor = "rgba(255, 159, 64, 0.6)"
                },
                new ChartViewModel.Dataset
                {
                    Label = "Pulpen",
                    Data = new[] { 10000000, 20000000, 30000000 },
                    BackgroundColor = "rgba(255, 99, 132, 0.6)"
                },
                new ChartViewModel.Dataset
                {
                    Label = "Rautan",
                    Data = new[] { 5000000, 15000000, 25000000 },
                    BackgroundColor = "rgba(54, 162, 235, 0.6)"
                },
                new ChartViewModel.Dataset
                {
                    Label = "Penghapus",
                    Data = new[] { 30000000, 40000000, 50000000 },
                    BackgroundColor = "rgba(255, 205, 86, 0.6)"
                },
                new ChartViewModel.Dataset
                {
                    Label = "Marker",
                    Data = new[] { 35000000, 45000000, 55000000 },
                    BackgroundColor = "rgba(75, 192, 192, 0.6)"
                }

            }
        };


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
