using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class OrderDetailManager(IOrderDetailRepository _repository) : IOrderDetailService
{
    public async Task<OrderDetail> AddAsync(OrderDetail entity)
    {
       return await _repository.AddAsync(entity);
    }

    public void Delete(OrderDetail entity)
    {
        _repository.Delete(entity);
    }

    public async Task<List<OrderDetail>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<OrderDetail> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public void Update(OrderDetail entity)
    {
        _repository.Update(entity);
    }
}