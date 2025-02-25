using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaryaVariaTest.Models;
using DaryaVariaTest.Services;
using DaryaVariaTest.Models.Api.Request;
using Microsoft.AspNetCore.Authorization;

namespace DaryaVariaTest.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class HomeApiController : ControllerBase
{
    private readonly ILogger<HomeApiController> _logger;
    private readonly OrderServices _service;

    public HomeApiController(ILogger<HomeApiController> logger, OrderServices services) {
        _logger = logger;
        _service = services;
    }

    [HttpPost("transactions")]
    public IActionResult ProcessTransaction(TransactionApiRequest req) {
        var res = _service.CreateNewTransaaction(req);
        if (!res.Success) {
            return StatusCode(500, res);
        }
        return Ok(res);
    }

    [HttpGet("detail/{transactionId}")]
    public IActionResult GetDetail(int transactionId) {
        if (transactionId == 0) {
            return BadRequest("transactionId must great than 0");
        }
        
        var res = _service.GetDetailTransaction(transactionId);
        
        if(res.StatusCode == 400) {
            return BadRequest("");
        } else if(res.StatusCode == 500) {
            return StatusCode(res.StatusCode, res);
        }

        return Ok(res);
    }

    [HttpGet("Get-all-Role")]
    public IActionResult GetAllRole() {
        return Ok();
    }

    [HttpPost("deliver-update-date")]
    public IActionResult DeliverUpdateDate(DelivaryDateRequest ddr) {
        var res = _service.UpdateDelivaryDate(ddr);
        if (!res.Success) {
            return StatusCode(500, res);
        }
        return Ok(res);
    }

    [HttpPost("{role}/{approveReject}/{id}")]
    public IActionResult ApproveRejectManager(string role, string approveReject, int id) {
        var res = _service.ApproveRejectService(role, approveReject, id);
        if(!res.Success) {
            return StatusCode(500, res);
        }
        return Ok(res);
    }
}
