using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class BasketDetailRepository : GenericRepository<BasketDetail>, IBasketDetailRepository
{
    public BasketDetailRepository(SignalRContext _context) : base(_context)
    {

    }
}