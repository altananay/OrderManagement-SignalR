using Application.Abstractions;
using Application.Requests.SocialMedia;
using Application.Responses.SocialMedia;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController(ISocialMediaService _socialMediaService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllSocialMediasResponse>>>(_socialMediaService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaRequest request)
    {
        await _socialMediaService.AddAsync(_mapper.Map<CreateSocialMediaRequest, SocialMedia>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSocialMedia(Guid id)
    {
        var value = await _socialMediaService.GetByIdAsync(id);
        _socialMediaService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaRequest request)
    {
        _socialMediaService.Update(_mapper.Map<UpdateSocialMediaRequest, SocialMedia>(request));
        return Ok();
    }

    [HttpGet("/api/SocialMedia/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _socialMediaService.GetByIdAsync(id));
    }
}