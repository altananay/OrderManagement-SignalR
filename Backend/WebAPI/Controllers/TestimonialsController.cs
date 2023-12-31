using Application.Abstractions;
using Application.Requests.Testimonial;
using Application.Responses.Testimonial;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialsController(ITestimonialService _testimonialService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllTestimonialsResponse>>>(_testimonialService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialRequest request)
    {
        await _testimonialService.AddAsync(_mapper.Map<CreateTestimonialRequest, Testimonial>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTestimonial(Guid id)
    {
        var value = await _testimonialService.GetByIdAsync(id);
        _testimonialService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialRequest request)
    {
        _testimonialService.Update(_mapper.Map<UpdateTestimonialRequest, Testimonial>(request));
        return Ok();
    }

    [HttpGet("/api/Testimonial/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _testimonialService.GetByIdAsync(id));
    }
}