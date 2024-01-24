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

    public async Task<Basket> GetBasketByTableIdAsync(Guid id)
    {
        return await _context.Baskets.Where(b => b.TableId == id).FirstOrDefaultAsync();
    }
}