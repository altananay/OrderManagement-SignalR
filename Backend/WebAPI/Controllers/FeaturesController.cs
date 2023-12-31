using Application.Abstractions;
using Application.Requests.Feature;
using Application.Responses.Feature;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController(IFeatureService _featureService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllFeaturesResponse>>>(_featureService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureRequest request)
    {
        await _featureService.AddAsync(_mapper.Map<CreateFeatureRequest, Feature>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeature(Guid id)
    {
        var value = await _featureService.GetByIdAsync(id);
        _featureService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureRequest request)
    {
        _featureService.Update(_mapper.Map<UpdateFeatureRequest, Feature>(request));
        return Ok();
    }

    [HttpGet("/api/Feature/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _featureService.GetByIdAsync(id));
    }
}