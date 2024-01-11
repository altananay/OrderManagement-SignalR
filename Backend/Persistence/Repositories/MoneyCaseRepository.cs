using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class MoneyCaseRepository : GenericRepository<MoneyCase>, IMoneyCaseRepository
{
    private readonly SignalRContext _context;

    public MoneyCaseRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public async Task<decimal> GetTotalAmountFromMoneyCase()
    {
        return await _context.MoneyCases.Select(mc => mc.TotalAmount).FirstOrDefaultAsync();
    }

    public decimal GetTotalAmountFromMoneyCaseForSignalR()
    {
        return _context.MoneyCases.Select(mc => mc.TotalAmount).FirstOrDefault();
    }
}