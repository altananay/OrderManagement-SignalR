using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class DiscountManager(IDiscountRepository repository) : IDiscountService
{
    public async Task<Discount> AddAsync(Discount entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Discount entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Discount>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Discount> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Discount entity)
    {
        repository.Update(entity);
    }

    public async Task ChangeStatusToFalse(Guid id)
    {
        await repository.ChangeStatusToFalse(id);
    }

    public async Task ChangeStatusToTrue(Guid id)
    {
        await repository.ChangeStatusToTrue(id);
    }
}