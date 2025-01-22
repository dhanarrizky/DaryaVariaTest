using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaryaVariaTest.Models;
using DaryaVariaTest.Services;
using DaryaVariaTest.Models.Api.Request;

namespace DaryaVariaTest.Controllers;

[ApiController]
[Route("api/payments")]
public class InfoOfPaymentApiControlle : ControllerBase
{
    private readonly ILogger<InfoOfPaymentApiControlle> _logger;
    private readonly OrderServices _service;

    public InfoOfPaymentApiControlle(ILogger<InfoOfPaymentApiControlle> logger, OrderServices services) {
        _logger = logger;
        _service = services;
    }

    [HttpPost("payment")]
    public IActionResult ProcessPayment(PaymentRequest req) {
        var res = _service.ProcessOfPayment(req);
        if(res.StatusCode == 400) {
            return BadRequest(res);
        } else if(res.StatusCode == 500) {
            return StatusCode(res.StatusCode, res);
        }

        return Ok(res);
    }
}
