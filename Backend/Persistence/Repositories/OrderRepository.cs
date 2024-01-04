using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly SignalRContext _context;

    public OrderRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> GetOrderCount()
    {
        return await _context.Orders.CountAsync();
    }

    public async Task<int> GetActiveOrderCount()
    {
        return await _context.Orders.Where(o => o.Description == "Müşteri Masada").CountAsync();
    }

    public async Task<decimal> GetLastOrderPrice()
    {
        return await _context.Orders.OrderByDescending(o => o.Date).Take(1).Select(o => o.TotalPrice).FirstOrDefaultAsync();
    }
}