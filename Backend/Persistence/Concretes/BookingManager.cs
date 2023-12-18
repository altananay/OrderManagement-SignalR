using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class BookingManager(IBookingRepository repository) : IBookingService
{
    public void Add(Booking entity)
    {
        repository.Add(entity);
    }

    public void Delete(Booking entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Booking>> GetAll()
    {
        return await repository.GetAll();
    }

    public Booking GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(Booking entity)
    {
        repository.Update(entity);
    }
}