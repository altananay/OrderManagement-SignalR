using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    private readonly SignalRContext _context;

    public NotificationRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public Task<int> GetNotificationCountWithStatusFalse()
    {
        return _context.Notifications.Where(x => x.Status == false).CountAsync();
    }

    public int GetNotificationCountWithStatusFalseForSignalR()
    {
        return _context.Notifications.Where(x => x.Status == false).Count();
    }

    public List<Notification> GetAllNotificationsWithFalse()
    {
        return _context.Notifications.Where(x => x.Status == false).ToList();
    }

    public async Task NotificationStatusChangeToFalse(Guid id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        //todo: null check
        notification.Status = false;
        await _context.SaveChangesAsync();
    }

    public async Task NotificationStatusChangeToTrue(Guid id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        //todo: null check
        notification.Status = true;
        await _context.SaveChangesAsync();
    }
}