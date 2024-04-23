using Application.Abstractions;
using Application.Requests.Notification;
using Application.Responses.Notification;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController(INotificationService _notificationService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllNotificationsResponse>>>(_notificationService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationRequest request)
    {
        await _notificationService.AddAsync(_mapper.Map<CreateNotificationRequest, Notification>(request));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteNotification(Guid id)
    {
        var value = await _notificationService.GetByIdAsync(id);
        _notificationService.Delete(value);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNotification(UpdateNotificationRequest request)
    {
        _notificationService.Update(_mapper.Map<UpdateNotificationRequest, Notification>(request));
        return Ok();
    }

    [HttpGet("/api/Notifications/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _notificationService.GetByIdAsync(id));
    }

    [HttpGet("/api/Notifications/GetNotificationCountStatusFalse")]
    public async Task<int> GetNotificationCountWithStatusFalse()
    {
        return await _notificationService.GetNotificationCountWithStatusFalse();
    }

    [HttpGet("/api/Notifications/GetAllNotificationsWithStatusFalse")]
    public IActionResult GetAllNotificationsWithStatusFalse()
    {
        return Ok(_notificationService.GetAllNotificationsWithFalse());
    }

    [HttpGet("/api/Notifications/UpdateStatusToFalse/{id}")]
    public async Task<IActionResult> UpdateStatusToFalse(Guid id)
    {
        await _notificationService.NotificationStatusChangeToFalse(id);
        return Ok("Güncellendi");
    }

    [HttpGet("/api/Notifications/UpdateStatusToTrue/{id}")]
    public async Task<IActionResult> UpdateStatusToTrue(Guid id)
    {
        await _notificationService.NotificationStatusChangeToTrue(id);
        return Ok("Güncellendi");
    }
}