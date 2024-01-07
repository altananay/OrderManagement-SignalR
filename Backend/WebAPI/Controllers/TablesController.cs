using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesController(ITableService _tableService) : ControllerBase
{
    [HttpGet("/api/GetTableCount")]
    public async Task<IActionResult> GetTableCount()
    {
        return Ok(await _tableService.GetTableCount());
    }
}