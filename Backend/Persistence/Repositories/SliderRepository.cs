using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class SliderRepository : GenericRepository<Slider>, ISliderRepository
{
    public SliderRepository(SignalRContext _context) : base(_context)
    {
    }
}