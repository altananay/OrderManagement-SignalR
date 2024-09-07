using Application.Abstractions;
using Application.Requests.Message;
using Application.Responses.Message;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController(IMessageService _messageService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllMessagesResponse>>>(_messageService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessage(CreateMessageRequest request)
    {
        await _messageService.AddAsync(_mapper.Map<CreateMessageRequest, Message>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMessage(Guid id)
    {
        var value = await _messageService.GetByIdAsync(id);
        _messageService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMessage(UpdateMessageRequest request)
    {
        _messageService.Update(_mapper.Map<UpdateMessageRequest, Message>(request));
        return Ok();
    }

    [HttpGet("/api/Messages/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _messageService.GetByIdAsync(id));
    }
}