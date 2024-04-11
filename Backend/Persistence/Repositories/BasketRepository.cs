using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    private readonly SignalRContext _context;

    public BasketRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Basket>> GetAllBasketsWithProductAsync()
    {
        return await _context.Baskets.Include(b => b.Product).ToListAsync();
    }

    public async Task<List<Basket>> GetBasketByTableIdAsync(Guid id)
    {
        return await _context.Baskets.Where(b => b.TableId == id).Include(b => b.Product).ToListAsync();
    }
}