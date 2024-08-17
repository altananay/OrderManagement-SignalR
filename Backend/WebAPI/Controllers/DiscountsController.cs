using Application.Abstractions;
using Application.Requests.Discount;
using Application.Responses.Discount;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController(IDiscountService _discountService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllDiscountsResponse>>>(_discountService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscount(CreateDiscountRequest request)
    {
        await _discountService.AddAsync(_mapper.Map<CreateDiscountRequest, Discount>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDiscount(Guid id)
    {
        var value = await _discountService.GetByIdAsync(id);
        _discountService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscount(UpdateDiscountRequest request)
    {
        _discountService.Update(_mapper.Map<UpdateDiscountRequest, Discount>(request));
        return Ok();
    }

    [HttpGet("/api/Discounts/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _discountService.GetByIdAsync(id));
    }

    [HttpGet("/api/Discounts/StatusTrue/{id}")]
    public async Task<IActionResult> ChangeDiscountStatusToTrue(Guid id)
    {
        await _discountService.ChangeStatusToTrue(id);
        return Ok();
    }

    [HttpGet("/api/Discounts/StatusFalse/{id}")]
    public async Task<IActionResult> ChangeDiscountStatusToFalse(Guid id)
    {
        await _discountService.ChangeStatusToFalse(id);
        return Ok();
    }
}