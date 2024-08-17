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

    public async Task BookingStatusApproved(Guid id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            booking.Status = true;
        }    
        await _context.SaveChangesAsync();
    }

    public void BookingStatusCancelled(Guid id)
    {
        var booking = _context.Bookings.Find(id);
        if(booking != null)
        {
            booking.Status = false;
        }
        _context.SaveChanges();
    }
}