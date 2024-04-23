using Domain.Entities;

namespace Application.Repositories;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<int> GetNotificationCountWithStatusFalse();
    int GetNotificationCountWithStatusFalseForSignalR();
    List<Notification> GetAllNotificationsWithFalse();
    Task NotificationStatusChangeToTrue(Guid id);
    Task NotificationStatusChangeToFalse(Guid id);
}