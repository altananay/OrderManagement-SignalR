using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class AboutRepository : GenericRepository<About>, IAboutRepository
{
    public AboutRepository(SignalRContext _context) : base(_context)
    {
    }
}