using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    private readonly SignalRContext _context;

    public BookingRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public List<Booking> GetAll()
    {
        return _context.Bookings.ToList();
    }
}
