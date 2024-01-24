using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class BasketManager(IBasketRepository _repository) : IBasketService
{
    public Task<Basket> AddAsync(Basket entity)
    {
        return _repository.AddAsync(entity);
    }

    public void Delete(Basket entity)
    {
        _repository.Delete(entity);
    }

    public Task<List<Basket>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Basket> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public void Update(Basket entity)
    {
        _repository.Update(entity);
    }

    public Task<Basket> GetBasketByTableIdAsync(Guid id)
    {
        return _repository.GetBasketByTableIdAsync(id);
    }
}