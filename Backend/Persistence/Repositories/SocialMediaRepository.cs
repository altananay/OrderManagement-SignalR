using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
{
    public SocialMediaRepository(SignalRContext _context) : base(_context)
    {
    }
}
