using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class BasketManager(IBasketRepository _repository, IProductService productService) : IBasketService
{
    public async Task<Basket> AddAsync(Basket entity)
    {
        entity.ProductPrice = productService.GetByIdAsync(entity.ProductId).Result.Price;
        entity.TotalPrice = entity.ProductPrice * entity.ProductCount;
        entity.TableId = Guid.Parse("ec3610d7-877d-4225-af81-08dc1d21720c");
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