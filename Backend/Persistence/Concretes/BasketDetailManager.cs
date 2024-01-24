using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class BasketDetailManager(IBasketDetailRepository _repository) : IBasketDetailService
{
    public Task<BasketDetail> AddAsync(BasketDetail entity)
    {
        return _repository.AddAsync(entity);
    }

    public void Delete(BasketDetail entity)
    {
        _repository.Delete(entity);
    }

    public Task<List<BasketDetail>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<BasketDetail> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public void Update(BasketDetail entity)
    {
        _repository.Update(entity);
    }
}