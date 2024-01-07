using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService _orderService) : ControllerBase
{
    [HttpGet("/api/GetOrderCount")]
    public async Task<IActionResult> GetOrderCount()
    {
        return Ok(await _orderService.GetOrderCount());
    }

    [HttpGet("/api/GetActiveOrderCount")]
    public async Task<IActionResult> GetActiveOrderCount()
    {
        return Ok(await _orderService.GetActiveOrderCount());
    }

    [HttpGet("/api/GetLastOrderPrice")]
    public async Task<IActionResult> GetLastOrderPrice()
    {
        return Ok(await _orderService.GetLastOrderPrice());
    }

    [HttpGet("/api/GetTodayTotalPrice")]
    public async Task<IActionResult> GetTodayTotalPrice()
    {
        return Ok(await _orderService.GetTodayTotalPrice());
    }
}