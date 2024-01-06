using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class MoneyCaseManager(IMoneyCaseRepository _repository) : IMoneyCaseService
{
    public async Task<MoneyCase> AddAsync(MoneyCase entity)
    {
        return await _repository.AddAsync(entity);
    }

    public void Delete(MoneyCase entity)
    {
        _repository.Delete(entity);
    }

    public async Task<List<MoneyCase>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<MoneyCase> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public void Update(MoneyCase entity)
    {
        _repository.Update(entity);
    }

    public async Task<decimal> GetTotalAmountFromMoneyCase()
    {
        return await _repository.GetTotalAmountFromMoneyCase();
    }
}