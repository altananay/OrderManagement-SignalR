using Application.Abstractions;
using Application.Requests.About;
using Application.Responses.About;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mapper.Map<Task<List<GetAllAboutsResponse>>>(_aboutService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutRequest request)
        {
            _aboutService.Add(_mapper.Map<CreateAboutRequest, About>(request));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            var value = _aboutService.GetById(id);
            _aboutService.Delete(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutRequest request)
        {
            _aboutService.Update(_mapper.Map<UpdateAboutRequest, About>(request));
            return Ok();
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_aboutService.GetById(id));
        }
    }
}