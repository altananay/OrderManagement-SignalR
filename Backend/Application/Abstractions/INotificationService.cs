using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface INotificationService : IGenericService<Notification>
{
    Task<int> GetNotificationCountWithStatusFalse();
    int GetNotificationCountWithStatusFalseForSignalR();
    List<Notification> GetAllNotificationsWithFalse();
    Task NotificationStatusChangeToTrue(Guid id);
    Task NotificationStatusChangeToFalse(Guid id);
}