using Application.Abstractions;
using Application.Requests.Basket;
using Application.Responses.Basket;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController(IBasketService _basketService, IMapper _mapper) : ControllerBase
{
    [HttpGet("/api/Baskets")]
    public async Task<IActionResult> GetAllBaskets()
    {
        var values = await _mapper.Map<Task<List<GetAllBasketsResponse>>>(_basketService.GetAllBasketsWithProductAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBasket(CreateBasketRequest request)
    {
        Basket basket = _mapper.Map<CreateBasketRequest, Basket>(request);
        await _basketService.AddAsync(basket);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket(Guid id)
    {
        Basket basket = await _basketService.GetByIdAsync(id);
        _basketService.Delete(basket);
        return Ok();
    }

    [HttpGet("/api/Baskets/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Basket basket = await _basketService.GetByIdAsync(id);
        GetBasketResponse response = _mapper.Map<Basket, GetBasketResponse>(basket);
        return Ok(response);
    }

    [HttpPut("/api/Baskets")]
    public async Task<IActionResult> UpdateBasket(UpdateBasketRequest request)
    {
        Basket basket = _mapper.Map<UpdateBasketRequest, Basket>(request);
        _basketService.Update(basket);
        return Ok();
    }

    [HttpGet("/api/Baskets/GetByTableId/{id}")]
    public async Task<IActionResult> GetByTableId(Guid id)
    {
        var values = await _mapper.Map<Task<List<GetAllBasketsResponse>>>(_basketService.GetBasketByTableIdAsync(id));
        return Ok(values);
    }
}