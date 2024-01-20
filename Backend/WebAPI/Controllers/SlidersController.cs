using Application.Abstractions;
using Application.Requests.Slider;
using Application.Responses.Slider;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlidersController(ISliderService _sliderService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllSlidersResponse>>>(_sliderService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider(CreateSliderRequest request)
    {
        await _sliderService.AddAsync(_mapper.Map<CreateSliderRequest, Slider>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSlider(Guid id)
    {
        var value = await _sliderService.GetByIdAsync(id);
        _sliderService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateSliderRequest request)
    {
        _sliderService.Update(_mapper.Map<UpdateSliderRequest, Slider>(request));
        return Ok();
    }

    [HttpGet("/api/Sliders/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _sliderService.GetByIdAsync(id));
    }
}