using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IBookingService : IGenericService<Booking>
{
    List<Booking> GetAll();
}