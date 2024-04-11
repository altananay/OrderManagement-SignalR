using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class BasketManager(IBasketRepository _repository) : IBasketService
{
    public async Task<Basket> AddAsync(Basket entity)
    {
        return await _repository.AddAsync(entity);
    }

    public void Delete(Basket entity)
    {
        _repository.Delete(entity);
    }

    public async Task<List<Basket>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Basket> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public void Update(Basket entity)
    {
        _repository.Update(entity);
    }

    public async Task<List<Basket>> GetBasketByTableIdAsync(Guid id)
    {
        return await _repository.GetBasketByTableIdAsync(id);
    }

    public async Task<List<Basket>> GetAllBasketsWithProductAsync()
    {
        return await _repository.GetAllBasketsWithProductAsync();
    }
}