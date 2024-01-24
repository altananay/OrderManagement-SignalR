using Application.Abstractions;
using Application.Requests.BasketDetail;
using Application.Responses.BasketDetail;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketDetailsController(IBasketDetailService _basketDetailService, IMapper _mapper) : ControllerBase
{
    [HttpGet("/api/BasketDetails")]
    public async Task<IActionResult> GetAllBasketDetails()
    {
        var values = await _mapper.Map<Task<List<GetAllBasketDetailsResponse>>>(_basketDetailService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBasketDetail(CreateBasketDetailRequest request)
    {
        BasketDetail basketDetail = _mapper.Map<CreateBasketDetailRequest, BasketDetail>(request);
        await _basketDetailService.AddAsync(basketDetail);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasketDetail(Guid id)
    {
        BasketDetail basketDetail = await _basketDetailService.GetByIdAsync(id);
        _basketDetailService.Delete(basketDetail);
        return Ok();
    }

    [HttpGet("/api/BasketDetails/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        BasketDetail basketDetail = await _basketDetailService.GetByIdAsync(id);
        GetBasketDetailResponse response = _mapper.Map<BasketDetail, GetBasketDetailResponse>(basketDetail);
        return Ok(response);
    }

    [HttpPut("/api/BasketDetails")]
    public async Task<IActionResult> UpdateBasketDetail(UpdateBasketDetailRequest request)
    {
        BasketDetail basketDetail = _mapper.Map<UpdateBasketDetailRequest, BasketDetail>(request);
        _basketDetailService.Update(basketDetail);
        return Ok();
    }
}