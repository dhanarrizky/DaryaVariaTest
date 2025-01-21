using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaryaVariaTest.Models;
using DaryaVariaTest.Services;
using DaryaVariaTest.Models.Api.Request;

namespace DaryaVariaTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductApiController : ControllerBase
{
    private readonly ILogger<ProductApiController> _logger;
    private readonly ProductServices _service;

    public ProductApiController(ILogger<ProductApiController> logger, ProductServices services) {
        _logger = logger;
        _service = services;
    }

    [HttpGet("getAll")]
    public IActionResult ProcessTransaction() {
        var res = _service.GetAllProducts();
        return Ok(res);
    }
}
