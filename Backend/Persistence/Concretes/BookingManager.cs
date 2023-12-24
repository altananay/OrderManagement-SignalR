using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class BookingManager(IBookingRepository repository) : IBookingService
{
    public async Task<Booking> AddAsync(Booking entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Booking entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Booking>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Booking> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Booking entity)
    {
        repository.Update(entity);
    }
}