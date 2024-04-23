using Application.Abstractions;
using Application.Enums;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

internal class NotificationManager(INotificationRepository repository) : INotificationService
{
    public Task<Notification> AddAsync(Notification entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.Type = NotificationType.Message;
        entity.Status = false;
        return repository.AddAsync(entity);
    }

    public void Delete(Notification entity)
    {
        repository.Delete(entity);
    }

    public Task<List<Notification>> GetAllAsync()
    {
        return repository.GetAllAsync();
    }

    public Task<Notification> GetByIdAsync(Guid id)
    {
        return repository.GetByIdAsync(id);
    }

    public void Update(Notification entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.Type = NotificationType.Message;
        repository.Update(entity);
    }

    public Task<int> GetNotificationCountWithStatusFalse()
    {
        return repository.GetNotificationCountWithStatusFalse();
    }

    public int GetNotificationCountWithStatusFalseForSignalR()
    {
        return repository.GetNotificationCountWithStatusFalseForSignalR();
    }

    public List<Notification> GetAllNotificationsWithFalse()
    {
        return repository.GetAllNotificationsWithFalse();
    }

    public async Task NotificationStatusChangeToTrue(Guid id)
    {
        await repository.NotificationStatusChangeToTrue(id);
    }

    public async Task NotificationStatusChangeToFalse(Guid id)
    {
        await repository.NotificationStatusChangeToFalse(id);
    }
}