using Application.Abstractions;
using Application.Requests.MoneyCase;
using Application.Responses.MoneyCase;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoneyCasesController(IMoneyCaseService _moneyCaseService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllMoneyCasesResponse>>>(_moneyCaseService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateMoneyCaseRequest request)
    {
        await _moneyCaseService.AddAsync(_mapper.Map<CreateMoneyCaseRequest, MoneyCase>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAbout(Guid id)
    {
        var value = await _moneyCaseService.GetByIdAsync(id);
        _moneyCaseService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateMoneyCaseRequest request)
    {
        _moneyCaseService.Update(_mapper.Map<UpdateMoneyCaseRequest, MoneyCase>(request));
        return Ok();
    }

    [HttpGet("/api/MoneyCases/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _moneyCaseService.GetByIdAsync(id));
    }

    [HttpGet("/api/MoneyCases/GetTotalAmountFromMoneyCase")]
    public async Task<IActionResult> GetTotalAmountFromMoneyCase()
    {
        return Ok(await _moneyCaseService.GetTotalAmountFromMoneyCase());
    }
}