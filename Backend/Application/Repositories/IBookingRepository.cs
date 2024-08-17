using Domain.Entities;

namespace Application.Repositories;

public interface IBookingRepository : IGenericRepository<Booking>
{
    List<Booking> GetAll();
    Task BookingStatusApproved(Guid id);
    void BookingStatusCancelled(Guid id);
}