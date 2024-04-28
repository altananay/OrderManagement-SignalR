using Application.Abstractions;
using Application.Requests.Table;
using Application.Responses.Table;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesController(ITableService _tableService, IMapper _mapper) : ControllerBase
{
    [HttpGet("/api/GetTableCount")]
    public async Task<IActionResult> GetTableCount()
    {
        return Ok(await _tableService.GetTableCount());
    }

    [HttpGet("/api/Tables")]
    public async Task<IActionResult> GetAllTables()
    {
        var values = await _mapper.Map<Task<List<GetAllTablesResponse>>>(_tableService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTable([FromBody] CreateTableRequest request)
    {
        Table table = _mapper.Map<CreateTableRequest, Table>(request);
        await _tableService.AddAsync(table);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTable(Guid id)
    {
        Table table = await _tableService.GetByIdAsync(id);
        _tableService.Delete(table);
        return Ok();
    }

    [HttpGet("/api/Tables/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Table table = await _tableService.GetByIdAsync(id);
        GetTableResponse response = _mapper.Map<Table, GetTableResponse>(table);
        return Ok(response);
    }

    [HttpPut("/api/Tables")]
    public async Task<IActionResult> UpdateTable(UpdateTableRequest request)
    {
        Table table = _mapper.Map<UpdateTableRequest, Table>(request);
        _tableService.Update(table);
        return Ok();
    }
}