using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
{
    private readonly SignalRContext _context;

    public DiscountRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public async Task ChangeStatusToFalse(Guid id)
    {
        var discount = await _context.Discounts.FindAsync(id);
        if (discount != null)
        {
            discount.Status = false;
        }
        await _context.SaveChangesAsync();
    }

    public async Task ChangeStatusToTrue(Guid id)
    {
        var discount = await _context.Discounts.FindAsync(id);
        if (discount != null)
        {
            discount.Status = true;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<List<Discount>> GetAllByStatusTrue()
    {
        var values = await _context.Discounts.Where(x => x.Status == true).ToListAsync();
        return values;
    }
}