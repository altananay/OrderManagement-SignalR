using Microsoft.AspNetCore.SignalR;
using Persistence.Contexts;

namespace WebAPI.Hubs;

public class SignalRHub(SignalRContext _context) : Hub
{
    public async Task SendCategoryCount()
    {
        var value = _context.Categories.Count();
        await Clients.All.SendAsync("ReceiveCategoryCount", value);
    }
}