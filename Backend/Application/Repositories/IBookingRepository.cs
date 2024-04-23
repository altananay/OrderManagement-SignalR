using Domain.Entities;

namespace Application.Repositories;

public interface IBookingRepository : IGenericDal<Booking>
{
    List<Booking> GetAll();
}