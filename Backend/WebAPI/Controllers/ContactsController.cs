using Application.Abstractions;
using Application.Requests.Contact;
using Application.Responses.Contact;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mapper.Map<Task<List<GetAllContactsResponse>>>(_contactService.GetAllAsync());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactRequest request)
        {
            await _contactService.AddAsync(_mapper.Map<CreateContactRequest, Contact>(request));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var value = await _contactService.GetByIdAsync(id);
            _contactService.Delete(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactRequest request)
        {
            _contactService.Update(_mapper.Map<UpdateContactRequest, Contact>(request));
            return Ok();
        }

        [HttpGet("/api/Contact/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _contactService.GetByIdAsync(id));
        }
    }
}