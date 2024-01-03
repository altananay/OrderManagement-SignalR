using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class OrderManager(IOrderRepository _repository) : IOrderService
{
    public async Task<Order> AddAsync(Order entity)
    {
        return await _repository.AddAsync(entity);
    }

    public void Delete(Order entity)
    {
        _repository.Delete(entity);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public void Update(Order entity)
    {
        _repository.Update(entity);
    }
}